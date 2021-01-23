    public class CollectionInitializable : IEnumerable
    {
        public void Add(int value) { ... }
        public void Add(string key, int value) { ... }
        public IEnumerator GetEnumerator() { ... }
    }
    var obj = new CollectionInitializable
    {
        1,
        { "two", 3 },
    };
