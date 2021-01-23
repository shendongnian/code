    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    namespace ImportComuni
    {
        class Program
        {
            static void Main(string[] args)
            {
                int i = 1;
                StreamReader reader = File.OpenText("d:\\comunidatabase.txt");
                StreamWriter writer = new StreamWriter("d:\\mysqlcomuni.csv");
                string line = "";
                while ((line = reader.ReadLine()) != null)
                {
                    writer.WriteLine(i + "," + "\"" + line + "\"," + "\"" + a + "\"");
                    i++;                
                }
                                   
           }
      }    
    }      
