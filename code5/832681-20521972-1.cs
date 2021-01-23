    public class CustomList<T> : IList<T>, IList
    {
        // this is the one we want users of this class to use
        public void Add(T value) { ... }
        // IList's implementation; needs to exist, but this way it's hidden,
        // unless you cast to IList
        int IList.Add(object value) { this.Add((T)value); return this.Count - 1; }
        // etc
    }
