    public static class ObjectCreator()
    {
        public T Create<T>() where T : new()
        {
            return new T();
        }
    }
