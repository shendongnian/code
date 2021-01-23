    class GenericWrapper<T>
    {
        public T Item { get; set; }
        public static implicit operator T(GenericWrapper<T> value)
        {
            //this one
            return value.Item;
            //that is a MemoryStream
        }
    }
