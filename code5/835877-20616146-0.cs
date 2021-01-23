    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    namespace ConsoleApplication1
    {
       class Program
        { 
            string filepath = "C:\\Users\\Guest\\Desktop\\hi.txt"; // use these as common
            FileStream fs = new FileStream(filepath,FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine("6,73,6,71");
            sw.WriteLine("32,1,0,12");
            sw.WriteLine("3,11,1,134");
            sw.WriteLine("43,15,43,6");
            sw.WriteLine("55,0,4,12");
            sw.Close();
            string buffer = "";
            FileStream fs1 = new FileStream(filepath, FileMode.Open); // changes are here in FileMode
            StreamReader sr = new StreamReader(fs1);
            int[,] data = new int[5, 4]; // your array index is short
            int i = 0, j = 0;
            while ((buffer = sr.ReadLine()) != null)
            {
                var row = buffer.Split(',');
                foreach (var rowItem in row)
                {
                    data[i, j] = Convert.ToInt32(rowItem); 
                    j++;
                }
                i++; j = 0;
            }
        }
    }  
