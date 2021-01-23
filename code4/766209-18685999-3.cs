    class Class1
    {
        public virtual void DoSomething
        {
            Console.WriteLine("Class1.DoSomething");
        }
    }
    class Class2 : Class1
    {
        public new void DoSomething
        {
            Console.WriteLine("Class2.DoSomething");
        }
    }
    class Class3 : Class1
    {
        public override void DoSomething
        {
            Console.WriteLine("Class3.DoSomething");
        }
    }
