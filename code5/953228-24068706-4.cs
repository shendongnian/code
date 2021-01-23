    public class Vector : IEquatable<Vector> //TODO consider renaming
    {
        public double Angle { get; set; }
        public double Width { get; set; }
        public override bool Equals(object obj)
        {
            return Equals(obj as Vector);
        }
        public bool Equals(Vector other)
        {
            if (other == null)
                return false;
            return Angle == other.Angle &&
                Width == other.Width;
        }
        public override int GetHashCode()
        {
            return new { Angle, Width }.GetHashCode();
        }
    }
