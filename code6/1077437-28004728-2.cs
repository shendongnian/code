    class Coordinate
    {
        double latitude;
        double longitude;
        public override bool Equals(object obj)
        {
            return Object.ReferenceEquals(this, obj)) ||
                   this == (other as Coordinate);
        }
        public static bool operator ==(Coordinate l, Coordinate r)
        {
            return (l == null && r == null) || (l != null && r != null) &&
                   // equality check including epsilons, edge cases, etc.
        }
        public static bool operator !=(Coordinate l, Coordinate r)
        {
            return !(l == r);
        }
    }
