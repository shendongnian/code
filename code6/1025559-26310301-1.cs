    public class Atlas<TValue> {
        public bool TryGetByIndex(int index, out TValue val);
        public void Add(int index, TValue val);
        public bool TryGetByName(string name, out TValue val);
        public void Add(string name, TValue val);
        public TValue this[string name] { get ... set ...}
        public TValue this[int index] { get ... set ...}
        // You may want to add more methods or properties here, for example to iterate atlas elements
    }
