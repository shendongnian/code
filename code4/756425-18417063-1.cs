    interface IFoo
    {
        void Foo();
    }
    
    struct Bar : IFoo
    {
        public void Foo()
        {
            // Do something
        }
    }
        
    class Test
    {
        static void DoFoo<T>(T value) where T : IFoo
        {
            value.Foo();
        }
        
        static void Main()
        {
            Bar bar = new Bar();
            DoFoo(bar); // No boxing involved
        }
    }
