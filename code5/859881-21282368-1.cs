    class A
    {
        public virtual void print() // Add "virtual"
        {
            Console.WriteLine("Class A");
        }
    }
    
    class B : A 
    {
        public override void print()// Add "override"
        {
            Console.WriteLine("Class B");
        }
    }
