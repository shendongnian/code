    public static class Container
    {
        static Container()
        {
            Users = new ConcurrentBag<User>();
        }
        public static IEnumerable<User> Users { get; set; }
        ...
    }
