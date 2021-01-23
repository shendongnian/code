    public class Table
    {
        public readonly XElement element;
    
        public Table(XElement element){ this.element = element; }
        public int Id { get { return (int)element.Attribute("Id"); } }
    
        public MyPair Parent
        { get { return _Parent ?? (_Parent = new MyPair(element.Element("Parent"))); } }
        MyPair _Parent;
    
        public MyPair Child
        { get { return _Child ?? (_Child = new MyPair(element.Element("Child"))); } }
        MyPair _Child;
    }
