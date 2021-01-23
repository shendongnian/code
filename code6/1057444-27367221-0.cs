    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            public static IEnumerable<string> Helper() // Neccessary to use in foreach loop
            {
                yield return "Code";
                yield return "Desc";
                yield break;
            }
            static void Main(string[] args)
            {
                Dictionary<string, List<string>> container = new Dictionary<string, List<string>>();
                List<string> l1 = new List<string>();
                List<string> l2 = new List<string>();
    
                l1.Add("l1s1");
                l1.Add("l1s2");
                l1.Add("l1s3");
    
                l2.Add("l2s1");
                l2.Add("l2s2");
                l2.Add("l2s3");
    
                container.Add("Code", l1);
                container.Add("Desc", l2);
    
                int count = 0;
                foreach (string k in Helper()) // get all Keys
                {
                    for (int i = 0; i < container[k].Count; i++)
                    {
                        Console.WriteLine(container[k][i].ToString()); // Write each element in list
                        count++;
                    }
                    Console.WriteLine();
                }
                Console.WriteLine(count.ToString());
            }
        }
    }
