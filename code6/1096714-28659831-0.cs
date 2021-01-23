    using System;
    using Newtonsoft.Json.Linq;
    
    class Test
    {
        static void Main()
        {
            string json = "[\"ok\", \"Google\", \"google\"]";
            var array = JArray.Parse(json);
            Console.WriteLine(array[0]); // For example
        }
    }
