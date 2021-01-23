    public class Inner {
       public int IX {get;set;}
        public string IY {get;set;}
    }
    
    public class Outer {
        public int OX {get;set;}
        public IEnumerable<Inner> OI {get;set;}
    }
    
    public XDocument SerializeOuter(Outer obj)
    {
        return new XDocument(
            new XElement("Outer",
                new XAttribute("OX", obj.OX.ToString()),
                new XElement("Inners", from i in obj.OI
                                       select SerializeInner(i))));
    }
    
    private XElement SerializeInner(Inner obj)
    {
        return new XElement("Inner",
                            new XAttribute("IX", obj.IX),
                            new XElement("IY", obj.IY));
    }
