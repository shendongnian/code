    public static class InferHelper<TValue>
        where TValue : class
    {
        public static TValue Get<TKey>(TKey key)
        {
            // do your magic here and return a value based on your key
            return default(TValue);
        }
    }
