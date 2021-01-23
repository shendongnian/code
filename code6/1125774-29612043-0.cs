    interface SomeInterface { }
    class SomeClass : SomeInterface
    {
        public override string ToString()
        {
            return "SomeClass";
        }
    }
    class SomeOtherClass : SomeClass
    {
        public override string ToString()
        {
            return "SomeOtherClass";
        }
    }
