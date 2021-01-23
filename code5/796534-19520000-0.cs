    public class Foo : ICaseConverterContracts
    {
        public Foo()  // does not compile as the base class constructor is inaccessible
        {
        }
    }
