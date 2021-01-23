    public class circle : shape
    {
        public int Radius { get; set; }
        public circle(string id, string name, int radius)
            : base(id, name)
        {
            this.Radius = radius;
        }
        public circle(XElement element)
            : base(element)
        {
            this.Radius = int.Parse(element.Attribute("radius").Value);
        }
        public override XElement GetXElement()
        {
            return new XElement("circle", new XAttribute("id", this.id), new XAttribute("radius", this.Radius), this.Name);
        }
        public override double Area()
        {
            return Math.PI * Radius * Radius;
        }
    }
