    public  class FSegment
    {
        [XmlIgnore]
        public List<Segment> OutProperty {get;set;}    
        [XmlArray("OutProperty");
        public Segment[] _OutProperty
        {
            get { return OutProperty.ToArray(); }
            set { OutProperty = new List<Segment>(value); }
        } 
    }
