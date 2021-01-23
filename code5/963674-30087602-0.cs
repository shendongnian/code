    public class Builder<T> where T : new()
    {
        public T Build()
        {
            return new T();
        }
    }
