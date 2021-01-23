    public class Category
    {
        public readonly XElement self;
        public readonly XNamespace ns;
        public Category(XNamespace xn, XElement cat) { self = cat; ns = xn; }
        public string Name { get { return (string)self.Attribute("varName"); } }
        public Cell Cell { get { return _Cell ?? (_Cell = new Cell(self.Elements(ns+"cell").First())); } }
        Cell _Cell;
    }
    
    public class Cell
    {
        public readonly XElement self;
        public Cell(XElement cell) { self = cell; }
        public string Name { get { return (string)self.Attribute("varName"); } }
        public string Number { get { return (string)self.Attribute("number"); } }
        public string Date { get { return (string)self.Attribute("date"); } }
        public string Label { get { return (string)self.Attribute("date"); } }
    }
    
    public class Dimension
    {
        public readonly XElement self;
        public readonly XNamespace ns;
        public Dimension(XNamespace xn, XElement dim) { self = dim; ns = xn; }
        public string Axis { get { return (string)self.Attribute("axis"); } }
        public string Text { get { return (string)self.Attribute("text"); } }
        public string BatchNo { get { return self.Parent.Parent.Attribute("number").Value } }
        public string RunNo { get { return self.Parent.Attribute("number").Value } }
        public Category[] Categories
        { get { return _Categories ?? (_Categories = self.Elements(ns + "category")
                                 .Select(cat => new Category(ns, cat))
                                 .ToArray()); }
        }
        Category[] _Categories;
    }
