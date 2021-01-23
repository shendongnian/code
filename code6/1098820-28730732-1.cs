    using System;
    using System.IO;
    
    using Newtonsoft.Json;
    
    class Program
    {
        static void Main(string[] args)
        {
            string text = File.ReadAllText("Test.json");
            var json = JsonConvert.DeserializeObject<dynamic>(text);
            var data = json.data;
            foreach (var item in data)
            {
                Console.WriteLine(item.Href);
            }
        }
    }
