    class Compare : IEqualityComparer<YourClass>
        {
            public bool Equals(YourClass x, YourClass y)
            {
                //  add your comparison logic
                return x.Property == y.Property;
            }
            public int GetHashCode(YourClass something)
            {
                // return a hashcode based on your unique properties
                return something.Property.GetHashCode();
            }
        }
