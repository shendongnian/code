    using System;
    using Newtonsoft.Json.Linq;
    
    public class Test
    {
        public static void Main()
        {
            JObject json = new JObject();
            int[] array = { 1, 2, 3 };
            json["numbers"] = new JArray(array);
            Console.WriteLine(json);
        }
    }
