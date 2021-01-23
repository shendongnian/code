        public class JSONRoot
        {
            public catalog catalog { get; set; }
        }
        // ...
        string xml = File.ReadAllText(@"D:\file.xml");
        var catalog1 = xml.ParseXML<catalog>();
            
        string json = File.ReadAllText(@"D:\file.json");
        var catalog2 = json.ParseJSON<JSONRoot>();
        
