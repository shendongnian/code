    public static class External
    {
        public static void ThirdPartyMethod<T>(IEnumerable<T> items)
        {
            Console.WriteLine(typeof(T).Name);
        }
    }
