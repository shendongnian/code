    public void Insert<T>(YourWrap<T> instance);
        public class YourWrap<T>
        {
            public IFormatter<T> Formatter { get; set; }
            public T Parameter { get; set; }
        }
