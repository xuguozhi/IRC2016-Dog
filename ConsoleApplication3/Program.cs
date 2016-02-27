using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using LumenWorks.Framework.IO.Csv;
namespace ConsoleApplication3
{
    class Program
    {

        static void Main(string[] args)
        {
           
            string s;
            string label;
            using (CsvReader csv =
            new CsvReader(new StreamReader("D:/dogdataset/Clickture_dog_Thumb.tsv"), true))
          {
        int fieldCount = csv.FieldCount;
        int i = 1;
        string[] headers = csv.GetFieldHeaders();
        
        while (csv.ReadNextRecord())
        {
            label = csv[0];
            string[] split = label.Split(new Char[] { '\t' });
            string directory = @"D:\dogdataset\"+split[0]+"\\";
            string filename = i.ToString();
            string othername = @".jpg";
            s = split[2];
            string path = directory + filename + othername;
         if (!Directory.Exists(directory)) { Directory.CreateDirectory(directory); } 
            File.WriteAllBytes(path, Convert.FromBase64String(s));
            i++;
        }
    }
    }
    }
}
