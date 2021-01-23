    abstract class A
    {
        abstract void DoSomething();
    }
    class Master
    {
        public A a;
        public void DoSomething()
        {
            a.DoSomething();
            // Logic to determine next A ...
            a = new A2();
        }
    }
    class A1 : A
    {
        public override void DoSomething()
        {
            //do Work
        }
    }
    class A2 : A
    {
        public override void DoSomething()
        {
            //do Different Work
        }
    }
