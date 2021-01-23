    public class Circle2
    {
        public double Diameter { get; set; }
        public double Radius { get { return Diameter / 2; } set { Diameter = value*2; } }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeRadius() {return false;}
    }
