    using System;
    using Newtonsoft.Json;
    
    namespace TestJson
    {
        class Test {
            public double? amount { get; set; }
        }
    
        class MainClass
        {
            public static void Main(string[] args)
            {
                string jsonStr = JsonConvert.SerializeObject(new Test());
                string jsonStr2 = JsonConvert.SerializeObject(new Test { amount = 5 } );
                Console.WriteLine(jsonStr);
                Console.WriteLine(jsonStr2);
                Console.ReadLine();
            }
        }
    }
