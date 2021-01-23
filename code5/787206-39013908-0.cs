    using System;
    using System.Linq;
    
    namespace ConsoleApplication5
    {
        public class Test
        {
                public static void Main()
                {
                    string[] stringArray = { "Nathan", "Bob", "Tom" };
                    bool exists = stringArray.Any(x => x.Equals("Nathan"));
                    Console.WriteLine(exists);
                }
         }
    }
