    class Coordinate
    {
        double latitude;
        double longitude;
        public override bool Equals(object obj)
        {
            if (Object.ReferenceEquals(obj)) { return true; }
            var other = obj as Coordinate;
            return other != null && this == other;
        }
        public static bool operator ==(Coordinate l, Coordinate r)
        {
            return (l == null && r == null) || (l != null && r != null) &&
                    l.latitude == r.latitude && l.longitude == r.longitude;
        }
        public static bool operator !=(Coordinate l, Coordinate r)
        {
            return !(l == r);
        }
    }
