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
        readonly X x = new X();
        public override void Go()
        {
            x.DoSomething(); // !
        }
    }
