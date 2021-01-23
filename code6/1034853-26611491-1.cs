        public class SampleClass<T, TCollection>
            where TCollection : IList<T>, IReadOnlyList<T>, new()
        {
            public SampleClass() : this(new TCollection()) { }
            public SampleClass(TCollection collection) { ... }
        }
