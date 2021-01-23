    class InheritanceTesting
    {
        public virtual void InheritanceOne()
        {
            Console.WriteLine("InheritanceOne");
        }
    }
    
    class NewInherit : InheritanceTesting 
    {
        public override void InheritanceOne()
        {
            Console.WriteLine("InheritanceTwo");
        } 
     }
