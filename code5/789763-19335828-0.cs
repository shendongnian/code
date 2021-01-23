    class Foo
    {
        public Foo() { throw new Exception("boom"); }
    }
    class Bar
    {
        private static Foo baz = new Foo();
        public Bar()
        {
            //trying to create a Bar will throw TypeInitializationException
        }
        public static void BarNone()
        {
            //trying to call a static method on Bar will throw TypeInitializationException
        }
    }
