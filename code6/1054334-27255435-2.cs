    public class MyComparer : IEqualityComparer<string>
    {
        public bool Equals(string one, string two)
        {
            return one.Equals(two, StringComparison.OrdinalIgnoreCase);
        }
    
        public int GetHashCode(string item)
        {
            return item.GetHashCode();
        }
    }
