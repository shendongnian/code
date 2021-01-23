    class Base
    {
        public Base()
        {
            Go();
        }
        public virtual Go() {}
    }
    class Derived : Base
    {
        X x = new X();
        public override void Go()
        {
            x.DoSomething(); // !
        }
    }
