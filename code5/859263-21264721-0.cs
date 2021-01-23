    class Outer
    {
        protected class Nested
        {
        }
    }
    
    class Derived : Outer
    {
        static void Foo()
        {
            var x = new Outer.Nested(); // Valid
        }
    }
    
    class NotDerived
    {
        static void Foo()
        {
            var x = new Outer.Nested(); // Invalid
        }
    }
