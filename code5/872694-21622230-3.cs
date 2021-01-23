    class Base
    {
       // Other stuff...
    
       public virtual void M3()
       {
       }
    }
    
    class Derived : Base
    {
        public override void M3()
        {
            Console.WriteLine("M3 from DERIVED.");
        }
    }
