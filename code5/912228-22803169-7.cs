    class SubLogic
    {
    }
    abstract class CollectionType : SubLogic
    {
        public SubLogic[] Sub { get; set; }
    }
    class And : CollectionType
    {
    }
    class Or : CollectionType
    {
    }
    class SubElement : SubLogic
    {
        public string Attribute { get; set; }
    }
    [XmlRoot("elements")]
    class ElementCollection
    {
        public Element[] Elements {Get;Set}
    }
    class Element
    {
        public SubLogic Sub { Get; set;}
    }
