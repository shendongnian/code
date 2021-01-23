    class MyNullable<T> where T : struct
    {
        public T Value { get; set; }
        public static implicit operator T(MyNullable<T> value)
        {
            return value != null ? value.Value : default(T);
        }
        public static implicit operator MyNullable<T>(T value)
        {
            return new MyNullable<T> { Value = value };
        }
    }
    class Foo<T> where T : class
    {
        public T Item { get; set; }
        public bool IsNull()
        {
            return Item == null;
        }
    }
