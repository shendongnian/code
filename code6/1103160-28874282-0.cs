    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Newtonsoft.Json;
    
    public class ResultEntry
    {
        public string id { get; set; }
        public string name { get; set; }
        public string name_url { get; set; }
        public string region_path { get; set; }
    }
    
    
    public class RootObject
    {
        public bool status { get; set; }
        public Dictionary<int, ResultEntry> result { get; set; }
        public int time_valid_to { get; set; }
    }
    
    class Test
    {
        static void Main()
        {
            string json = File.ReadAllText("json.txt");
            var root = JsonConvert.DeserializeObject<RootObject>(json);
            Console.WriteLine(root.result[904].name);
        }
    }
