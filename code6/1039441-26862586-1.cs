    [XmlRoot(ElementName="dtag")]
    class D {
        [XmlElement("btag", Type = typeof(B))]
        [XmlElement("ctag", Type = typeof(C))]
        public List<A> Items { get; set; }
    }
