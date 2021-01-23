    public class MyCommonImplementation : IMyCommonStuff
    {
        public virtual int SomeMethod()
        {
            // Implementation goes here.
        }
    
        public string property1 { get; set; }
    
        public int property2 { get; set; }
    }
    
    public class MyConcreteSubclass : MyCommonImplementation, IMyCommonStuff
    {
        // Add only the things that make this concrete subclass special.  Everything
        // else is inherited from the base class
    }
