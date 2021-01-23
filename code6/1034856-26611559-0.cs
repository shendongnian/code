    public class SampleClass<T, TCollection> where TCollection : class, IList<T>, IReadOnlyList<T>, new()
    {
        private readonly TCollection _collection;
    
        public SampleClass() : this(new TCollection()) { }
    
        public SampleClass(TCollection collection)
        {
            _collection = collection;
        }
    }
