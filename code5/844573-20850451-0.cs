    class Base
    {
        public Base()
        {
            if (this is Derived) (this as Derived).Go();
        }
    }
    class Derived : Base
    {
        readonly X x = new X();
        public void Go()
        {
            x.DoSomething(); // !
        }
    }
