    public class YourClass
    {
        public int Value;
    }
    
    public class YourClassEqualityComparer : IEqualityComparer<YourClass>
    {
        public bool Equals(YourClass x, YourClass y)
        {
            return x.Value == y.Value;
        }
        public int GetHashCode(YourClass obj)
        {
            return obj.Value.GetHashCode();
        }
    }
