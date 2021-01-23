    public abstract class NaturalComparerObject : Comparer<string>
    {
        private Dictionary<string, string[]> _table;
        protected NaturalComparerObject()
        {
            _table = new Dictionary<string, string[]>();
        }
        public override int Compare(string x, string y)
        {
            // implementation omitted for brevity
        }
    }
