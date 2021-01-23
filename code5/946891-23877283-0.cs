    class NonGenericCollection : IEnumerable
    {
        public List<int> List { get; set; }
        
        public NonGenericCollection()
        {
            List = new List<int>();
        }
        public IEnumerator GetEnumerator()
        {
            return List.GetEnumerator();
        }
    }
