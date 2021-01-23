    [XmlElement(ElementName = "leg0")]
    public List<Leg> leg0 { get; set; }
    [XmlElement(ElementName = "leg1")]
    public List<Leg> leg1 { get; set; }
    [XmlIgnore] //You don't want to deserialize this property
    public List<Leg> AllLegs { 
    get
        {
            return leg0.Join(leg1);
        }
                              }
  }
