    public class Foo<T>
    {
        private T item;
        public bool IsNullOrDefault()
        {
            return Equals(item, default(T));
        }
    }
