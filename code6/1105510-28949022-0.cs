    class Compare : IEqualityComparer<YourClass>
        {
            public bool Equals(YourClass x, YourClass y)
            {
                return x.Property == y.Property;
            }
            public int GetHashCode(YourClass something)
            {
                return something.Property.GetHashCode();
            }
        }
