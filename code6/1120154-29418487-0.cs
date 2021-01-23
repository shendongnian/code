    //TODO come up with a better name
    public class Foo<T> : IEnumerable<T>
    {
        private IEnumerable<T> wrapped;
        public Foo(IEnumerable<T> wrapped)
        {
            this.wrapped = wrapped;
        }
        public bool HasBeenIterated { get; private set; }
        public IEnumerator<T> GetEnumerator()
        {
            HasBeenIterated = true;
            foreach (var item in wrapped)
                yield return item;
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
