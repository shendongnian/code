    class A : IEnumerable
    {
        private List<int> _evenList = new List<int>();
        private List<int> _oddList = new List<int>();
        
        public void Add(int value)
        {
            List<int> list = (value & 1) == 0 ? _evenList : _oddList;
            list.Add(value);
        }
        // Explicit interface implementation to discourage calling it.
        // Alternatively, actually implement it (and IEnumerable<int>)
        // in some fashion.
        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException("Not really enumerable...");
        }
    }
