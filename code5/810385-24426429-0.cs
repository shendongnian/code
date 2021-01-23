    [XmlType("root")]
    public class Root
    {
        //    [XmlIgnore]
        //    public bool ChildSpecified { get { return Child != null && Child.HasValues; }   }
        Child c;
        [XmlElement("child")]
        public Child Child { get { return c; } set { c = value; } }
        
        public bool ShouldSerializeChild()
        {
            return c.Name  != null;
        }
    }
