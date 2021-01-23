    class B : A
    {
        public virtual void Display()
        {
            Console.WriteLine("B");
        }
    }
    class C : B
    {
        public override void Display()
        {
            Console.WriteLine("C");
        }
    }
    B c = new C();
    c.Display(); // write C not B
