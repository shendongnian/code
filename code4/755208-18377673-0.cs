    class A
    {
        public virtual void F()
        {
            Console.WriteLine("A");
        }
    }
    class B : A
    {
        public override void F()
        {
            Console.WriteLine("B");
        }
        void Test()
        {
            F(); // Prints "B"
            this.F(); // Prints "B"
            base.F(); // Prints "A"
        }
    }
