    public class Class1
    {
        // Instead of using a concrete class, use an interface
        // also, promote it to field
        IFoo _foo;
        // Create a constructor that accepts the interface
        public Class1(IFoo foo)
        {
            _foo = foo;
        }
        // alternatively use constructor which provides a default implementation
        public Class1() : this(new MyClass())
        {
        }
	
        public void Process()
        {
            // Don't initialize foo variable here
            var o = _foo.GetCountry();
            //Business Logic here
        }
    }
