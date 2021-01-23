    public class Base
    {
        public Base Clone() { return CloneImpl(); }
        protected virtual Base CloneImpl() { ... }
    }
    
    public class Derived : Base
    {
        public new Derived Clone() { ... }
        protected override Base CloneImpl() { return Clone(); }
    }
