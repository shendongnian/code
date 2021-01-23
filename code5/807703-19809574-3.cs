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
