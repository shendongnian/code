    private static void Main(string[] args)
        {
            var cache = new InMemoryCache();
            var tt = new SomeContextImpl();
            cache.Get<SomeContextImpl, string>(x => x.Any("hello", "hi"));
            Console.ReadKey();
        }
