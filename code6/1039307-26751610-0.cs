    class Base
    {
        public virtual void OverrideMe()
        {
            Console.WriteLine("I'm the base");
        }
    }
    class Derived : Base
    {
        public override void OverrideMe()
        {
            Console.WriteLine("I'm derived");
        }
    }
    class Shadowing : Base
    {
        public void OverrideMe()
        {
            Console.WriteLine("I'm shadowing");
        }
    }
