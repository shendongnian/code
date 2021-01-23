    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication1
    {
        class Program
        {
    
            static void Main(string[] args)
            {
                List<string> datas = new List<string>() { "Entry1", "Metadata1", "Metadata2", "Entry2", "Metadata3", "Metadata4" };
                List<List<string>> grouped = new List<List<string>>();
                int count = -1;
                foreach (string e in datas)
                {
                    if (e.StartsWith("Entry"))
                    {
                        grouped.Add(new List<string>());
                        grouped[++count].Add(e);
                    }
                    else
                    {
                        grouped[count].Add(e);
                    }
                }
                for (int i = 0; i < grouped.Count; i++)
                {
                    for (int j = 0; j < grouped[i].Count; j++)
                    {
                        Console.WriteLine(grouped[i][j]);
                    }
                    Console.WriteLine();
                }
    
    
            }
        }
    }
