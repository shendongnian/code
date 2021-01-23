    public class SomeClass
    {
        [XmlIgnore]
        public DateTime SomeDate { get; set; }
    
        [XmlElement("SomeDate")]
        public string SomeDateString
        {
            get { return this.SomeDate.ToString("yyyy-MM-dd HH:mm:ss"); }
            set { this.SomeDate = DateTime.Parse(value); }
        }
    }
