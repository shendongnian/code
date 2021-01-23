    class A
    {
        public virtual void print() 
        {
            Console.WriteLine("Class A");
        }
    }
    
    class B : A 
    {
        public override void print()
        {
            Console.WriteLine("Class B");
        }
    }
