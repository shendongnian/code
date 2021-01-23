    public class SpecialDictionary : IEnumerable<MyClass>
    {
        private readonly Dictionary<Guid, MyClass> inner = new Dictionary<Guid, MyClass>();
        public void Add(MyClass item)
        {
            inner.Add(item.Id, item);
        }
    
        public MyClass this[Guid id]
        {
            get { return inner[id]; }
            set { inner[id] = value; }
        }
        public bool TryGetValue(Guid id, out MyClass value)
        {
            return inner.TryGetValue(id, out value);
        }
        public IEnumerator<MyClass> GetEnumerator()
        {
            return inner.Values.GetEnumerator();
        }
        public int Count { get { return inner.Count; } }
    
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
