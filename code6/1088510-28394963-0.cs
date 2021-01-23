    using System;
    using System.Collections.Generic;
    
    namespace ConsoleApplication1
    {
        internal class Program
        {
            private static void Main(string[] args)
            {
                // an example of list of strings
                List<string> names = new List<string>();
                names.Add("Mike");
                names.Add("Sarah");
                List<string> families = new List<string>();
                families.Add("Ahmadi");
                families.Add("Ghasemi");
    
                // 1st way
                List<List<string>> outsideList = new List<List<string>>();
                outsideList.Add(names);
                outsideList.Add(families);
    
    
                // 2nd way
                Dictionary<string, List<string>> d = new Dictionary<string, List<string>>();
                d.Add("first", names);
                d.Add("second", families);
    
                // how to access list<list<>>
                foreach (List<string> list in outsideList)
                {
                    foreach (string s in list)
                        Console.WriteLine(s);
                }
                // how to access list inside dictionary
                foreach (List<string> list in d.Values)
                {
                    foreach (string s in list)
                        Console.WriteLine(s);
                }
            }
        }
    }
