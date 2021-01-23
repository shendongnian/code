    public class RootClass
    {
        public RootClass(int foo)
        {
        }
    }
    public class SubClass: RootClass
    {
        public SubClass(int foo)
        : base(foo)   // calls RootClass constructor
        {
            // now set Subclass fields
        }
    }
