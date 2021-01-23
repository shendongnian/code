    public class Reqs {
        public Source Source {get;set;}    
    }
    public class Source {
        public Sec Sec {get;set;}
    }
    public class Sec {
        [XmlAttribute("name")]
        public string Name {get;set;}
        [XmlElement("Sec")]
        public Sec InnerSec { get; set; }
        public Req Req {get;set;}
    }
    public class Req {
        public string Content {get;set;}
        public string Title {get;set;}
        public string Pro {get;set;}
    }
