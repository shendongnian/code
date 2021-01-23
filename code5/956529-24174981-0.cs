    public class CustomComparer : IEqualityComparer<SomeClass>
    {
        public bool Equals(SomeClass x, SomeClass y)
        {
            return String.Equals(x.Item1, y.Item1, StringComparison.CurrentCultureIgnoreCase)
                   && String.Equals(x.Item2, y.Item2, StringComparison.CurrentCultureIgnoreCase)
                   && String.Equals(x.Item3, y.Item3, StringComparison.CurrentCultureIgnoreCase);
        }
        public int GetHashCode(SomeClass obj)
        {
            return string.Concat(obj.Item1.ToLower(),
                                 obj.Item2.ToLower(),
                                 obj.Item3.ToLower()).GetHashCode();
        }
    }
