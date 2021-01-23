    public class ElementMeasurement
    {
        public Element Element { get; set; }
        public double Value { get; set; }
        public string Field { get; set; }
        public DateTime Date { get; set; }
    }
    public class Element
    {
        public int ElementID { get; set; }
        public string Name { get; set; }
    }
