    public static class Test<T>
    {
        public static int GetInt(T source)
        {
            dynamic dynamicSource = source;
            return Convert.ToInt32(dynamicSource );
        }
    }
