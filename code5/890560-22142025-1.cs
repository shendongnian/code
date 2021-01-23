    public static class ObjectCreator()
    {
        public static T Create<T>() where T : new()
        {
            return new T();
        }
    }
