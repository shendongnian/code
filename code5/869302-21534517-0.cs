    class BaseClass
    {
        public virtual void Method1()
        {
            Console.WriteLine("Base - Method1");
        }
        public virtual void Method2()
        {
            Console.WriteLine("Base - Method2");
        }
    }
    class DerivedClass : BaseClass
    {
        public override void Method1()
        {
            Console.WriteLine("Derived - Method1");
        }
        public override void Method2()
        {
            Console.WriteLine("Derived - Method2");
        }
    }
