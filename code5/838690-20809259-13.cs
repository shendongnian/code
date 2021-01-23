    [Serializable]
    [XmlRoot("metadata")]
    public class Metadata
    {
        [XmlElement("entry")]
        public List<Entry> Entries { get; set; }
        public Metadata()
        {
            Entries = new List<Entry>();
        }
    }
