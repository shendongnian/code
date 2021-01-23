    public static class MyConfigClass
    {
        public static Lazy<Something> MyConfig = new Lazy<Something>(() => GetSomethings());
        public static Something GetSomethings()
        {
            // this will only be called once in your web application
        }
    }
