    public SomeType : IEnumerable<string> {
        private readonly List<string> someField = new List<string>();
        public IEnumerator<string> GetEnumerator()
        { return someField.GetEnumerator(); }
        IEnumerator IEnumerable.GetEnumerator()
        { return someField.GetEnumerator(); }
    }
