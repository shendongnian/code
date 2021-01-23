        public class SampleClass<T, TCollection>
            where TCollection : new, IList<T>, IReadOnlyList<T>
        {
            public SampleClass() : this(new TCollection()) { }
            public SampleClass(TCollection collection) { ... }
        }
