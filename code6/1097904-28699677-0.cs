    public class MyDictionary<department, TValue> : Dictionary<department, TValue>
    {
        public MyDictionary() : base() { }
        public MyDictionary(int capacity) : base(capacity) { }
    }
