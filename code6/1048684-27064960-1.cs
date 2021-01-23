    public class SomeClass
    {
        private int? _property1;
        public int Property1 { get { return (int)_property1.Value; } } // will throw
        public SomeClass() {}
        public int SomeMethod()
        {
           int val = _property1.Value; // will throw
           ...
           return 123;
        }
    }
