    using System;
    using Newtonsoft.Json;
    
    public class MyObject
    {
        [JsonProperty("@name")]
        public string Name { get; set; }
        [JsonProperty("@surname")]
        public string Surname{ get; set; }
    }
    
    class Test
    {
        static void Main()
        {
            var x = new MyObject { Name = "Bob", Surname = "The Builder" };
            Console.WriteLine(JsonConvert.SerializeObject(x));
        }
    }
