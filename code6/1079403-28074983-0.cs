    using System;
    using System.IO;
    using System.Linq;
    using Newtonsoft.Json.Linq;
    
    class Test
    {
        static void Main(string[] args)
        {
            string text = File.ReadAllText("Test.json");
            JObject json = JObject.Parse(text);
            var ids = from bank in json["bank"]
                      from endpoint in bank["endpoints"]
                      where (string) endpoint["epName"] == "FRED001"
                      select (string) endpoint["epId"];
            foreach (var id in ids)
            {
                Console.WriteLine(id);
            }
        }
    }
