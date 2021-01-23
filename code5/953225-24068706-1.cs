    public class Foo : IEquatable<Foo> //TODO give better name
    {
        public double Angle { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public override bool Equals(object obj)
        {
            return Equals(obj as Foo);
        }
        public bool Equals(Foo other)
        {
            if (other == null)
                return false;
            return Angle == other.Angle &&
                Width == other.Width &&
                Height == other.Height;
        }
        public override int GetHashCode()
        {
            return new { Angle, Width, Height }.GetHashCode();
        }
    }
