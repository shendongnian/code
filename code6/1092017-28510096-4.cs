    public abstract class Toy
    {
        public string Manufacturer { get; set; }
    }
    public class Elephant : Toy
    {
        public int TrunkLength { get; set; }
    }
    public class Car : Toy
    {
        public Color Color { get; set; }
    }
