    public class SafeArray<T>
    {
        private T[] items;
        public SafeArray(int capacity)
        {
            items = new T[capacity];
        }
        public object this[int index]
        {
            get
            {
                return index < items.Length ? (object)items[index] : null;
            }
            set
            {
                items[index] = (T)value;
            }
        }
    }
    public class TestClass
    {
        public TestClass()
        {
            Ids = new SafeArray<int>(5);
            Instances = new SafeArray<MyClass>(5);
        }
        ...
        public SafeArray<int> Ids { get; private set; }
        public SafeArray<MyClass> Instances { get; private set; }
    }
