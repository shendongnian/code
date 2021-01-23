    class TestShow 
    {
        public string id { get; set; }
        public string IMDB_ID { get; set; }
        public string Language { get; set; }
    }
    [XmlRoot("Data")]
    class Data 
    {
        [XmlElement("Series")]
        public TestShow TestShow { get; set; }
    }
