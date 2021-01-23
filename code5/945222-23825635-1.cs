    class MyClassBuilder
    {
        public MyClassBuilder(LogFactory factory)
        {
            _factory = factory;
        }
        // ... Builder methods
        public MyClass Build()
        {
            return new MyClass(_factory.CreateLogger(), _param1);
        }
    }
