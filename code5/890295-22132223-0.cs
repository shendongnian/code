    class Base<T>
    {
        public virtual T MyProp { /* ... */ }
    }
    // Derived class that uses string for prop
    class Derived1 : Base<string>
    {
        public override string MyProp { /* ... */ }
    }
    // Derived class that uses int for prop
    class Derived2 : Base<int>
    {
        public override int MyProp { /* ... */ }
    }
