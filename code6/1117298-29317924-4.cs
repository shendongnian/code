    [Serializable]
    [XmlType("race")]
    public class Race
    {
        [XmlElement("horse")]
      public  List<Horse> Horses { get; set; }
        [XmlAttribute("racename")]
        public string RaceName
        {
            get;
            set;
        }
        public Race()
        {
            Horses = new List<Horse>();
        }
    }
