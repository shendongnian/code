    XmlSerializer ser = new XmlSerializer(typeof(SO.Request));
    using(var f = File.Open(filename,FileMode.Open))
    {
        var requests = (SO.Request)ser.Deserialize(f);
    }
----
    public class SO
    {
        public class Request
        {
            public Authenticate Authenticate { get; set; }
            public List<Group> Fields { get; set; }
        }
        public class Authenticate
        {
            public string Username { get; set; }
            public string Token { get; set; }
        }
        public class Group
        {
            [XmlAttribute("name")]
            public string Name { get; set; }
            [XmlElement("Field")]
            public List<Field> Fields { get; set; }
        }
            
        public class Field
        {
            public string Name { get; set; }
            public string Type { get; set; }
        }
    }
