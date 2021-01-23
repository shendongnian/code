    public class Something<T> where T : new()
    {
        public T CreateInstance()
        {
            return new T();
        }
    }
