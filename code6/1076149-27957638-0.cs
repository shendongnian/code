    class InheritanceTesting
    {
        public void InheritanceOne() 
        // Java equivalent would be
        // public final void InheritanceA()
        {
            Console.WriteLine("InheritanceA - One");
        }
        
        public virtual void InheritanceB()
        // Java equivalent would be
        // public void InheritanceB() // note the removing of final
        {
            Console.WriteLine("InheritanceB - One");
        }
    }
    
    class NewInherit : InheritanceTesting
    {
        public new void InheritanceOne() 
        // There is no Java equivalent to this statement
        {
            Console.WriteLine("InheritanceA - Two");
        }
        
        public override void InheritanceB()
        // Java equivalent would be
        // public void InheritanceB()
        {
            Console.WriteLine("InheritanceB - Two");
        }
    }
