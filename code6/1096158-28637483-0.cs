    class MyClass : IEnumerable<object>
    {
        public string FirstProperty { get; set; }
        public int SecondProperty { get; set; }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public IEnumerator<object> GetEnumerator()
        {
            yield return FirstProperty;
            yield return SecondProperty;
        }
    }
