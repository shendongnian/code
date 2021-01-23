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
                base.F();
                Console.WriteLine("B");
            }
        
            void Test()
            {
                F(); // Prints "A B"
            }
        }
