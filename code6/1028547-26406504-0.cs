    using System;
    using System.IO;
    using Newtonsoft.Json.Linq;
    
    class Program
    {
        static void Main(string[] args)
        {
            string text = File.ReadAllText("test.json");
            JToken token = JToken.Parse(text);
            JObject json = JObject.Parse((string) token);
            Console.WriteLine(json);
        }
    }
