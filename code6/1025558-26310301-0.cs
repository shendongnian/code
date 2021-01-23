    public class Atlas<TValue> {
        public bool TryGetByIndex(int index, out TValue val);
        public void Add(int index, TValue val);
        public bool TryGetByName(string name, out TValue val);
        public void Add(string name, TValue val);
    }
