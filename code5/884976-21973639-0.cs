    public class Triangle
    {
    
        public double SideA { get; set; }
        public double SideB { get; set; }
        public double SideC { get; set; }
        public string Name { get; set; }
    
        public Triangle(double a, double b, double c, string n)
        {
            SideA = a;
            SideB = b;
            SideC = c;
            Name = n;
        }
    
        public override string ToString()
        {
            return Name;
        }
    }
