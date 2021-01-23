    class VehicleEqualityComparer: EqualityComparer<T>
    {
        public override int GetHashCode(Foo f)
        {
            // A reasonably decent hash code for this application.
            return (f.Make.GetHashCode() << 16)
                   | (f.Model.GetHashCode() >> 16)
                   ^ f.Year;
        }
        public bool Equals(Foo x, Foo y)
        {
            if (x == null && y == null) return true;
            if (x == null || y == null) return false;
            return x.Year == y.Year
                && x.Make == y.Make
                && x.Model == y.Model;
        }
    }
