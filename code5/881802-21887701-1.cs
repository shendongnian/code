    public class PayloadWrapper<T>
    {
        public T Item { get; set; }
        public IEnumerable<T> Items { get; set; }
    }
