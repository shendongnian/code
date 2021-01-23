    class BaseClass
    {
        public virtual void ShowMe()
        {
            Console.WriteLine("I'm the base class");
        }
    }
    
    class DerivedClass : BaseClass
    {
        public override void ShowMe() 
        {
            Console.WriteLine("I'm the derived class");
        }
    }
    
    // This will print "I'm the base class"
    BaseClass baseClass = new BaseClass();
    baseClass.ShowMe(); 
    
    // This will print "I'm the derived class"
    DerivedClass derivedClass = new DerivedClass();
    derivedClass.ShowMe(); 
    
    // This will print "I'm the derived class"
    // Reason: even if assigned to a BaseClass variable,
    // it's still a DerivedClass instance
    BaseClass baseClass2 = new DerivedClass();
    baseClass2.ShowMe(); 
    
    // This will generate a compiler error
    // Subclasses can behave like superclasses,
    // but the opposite is not possible
    DerivedClass derivedClass2 = new BaseClass();
    
