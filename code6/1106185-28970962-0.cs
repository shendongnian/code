    [Serializable]
    public class NumberManager
    {
        [XmlIgnore]
        public Numbers Numbers { get; set; }
        [XmlAttribute(AttributeName="Numbers")]
        public string NumbersString
        {
            get { return Numbers.ToString(); }
            set { Numbers = (Numbers) Enum.Parse(typeof (Numbers), value); }
        }
    }
