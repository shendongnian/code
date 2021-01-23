    class Foo2 : IEquatable<Foo2>
    {
        public int X { get; set; }
        public override bool Equals(object obj)
        {
            return this.Equals(obj as Foo2);
        }
        public bool Equals(Foo2 other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            // Optimization for a common success case. 
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            if (this.GetType() != other.GetType())
                return false;
            return (X == other.X);
        }
        public override int GetHashCode()
        {
            return this.X;
        }
        public static bool operator ==(Foo2 lhs, Foo2 rhs)
        {
            if (Object.ReferenceEquals(lhs, null))
            {
                if (Object.ReferenceEquals(rhs, null))
                {
                    return true;
                }
                return false;
            }
            return lhs.Equals(rhs);
        }
        public static bool operator !=(Foo2 lhs, Foo2 rhs)
        {
            return !(lhs == rhs);
        }
    }
