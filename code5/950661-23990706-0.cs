    public class Base
    {
        public Base Clone()
        {
            Base b = new Base();
            CloneImpl(b);
            return b;
        }
        protected virtual void CloneImpl(Base b) { ... }
    }
    
    public class Derived : Base
    {
        public new Derived Clone()
        {
            Derived d = new Derived();
            this.CloneImpl(d);
            return d;
        }
        protected override void CloneImpl(Base b)
        {
            Derived d = b as Derived;
            ...
            base.CloneImpl(d);
        }
    }
