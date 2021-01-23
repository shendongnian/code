    [XmlElement("players")]
    public Players Players { get;set;}
    ...
    public class Players
    {
        [XmlElement("skater")]
        public List<Skater> Skaters {get;set;}
        [XmlElement("goalie")]
        public List<Goalie> Goalies {get;set;}
    }
