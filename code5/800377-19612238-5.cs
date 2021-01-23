        public class JSONRoot
        {
            public catalog catalog { get; set; }
        }
        // ...
        string xml = File.ReadAllText(@"C:\path\to\xml\file.xml");
        var catalog1 = xml.ParseXML<catalog>();
            
        string json = File.ReadAllText(@"C:\path\to\json\file.json");
        var catalog2 = json.ParseJSON<JSONRoot>();
        
