    [XmlRoot("ArrayOfBloc")]
    public class BlocContainer
    {
        [XmlElement("Bloc")]
        public List<Bloc> BlocCollection { get; set; }
    }
    public class Table
    {
        [XmlAttribute("name")]
        public string name { get; set; }
        public List<Column> listColumn { get; set; }
        public Table() { listColumn = new List<Column>(); }
    }
    public class Column
    {
        [XmlAttribute("name")]
        public string name { get; set; }
        [XmlAttribute("value")]
        public string value { get; set; }
        [XmlAttribute("type")]
        public string type { get; set; }
        [XmlAttribute("pk")]
        public int pk { get; set; }
        [XmlAttribute("defaultValue")]
        public string defaultValue { get; set; }
        [XmlAttribute("nullable")]
        public int nullable { get; set; }
        public Column() { }
    }
