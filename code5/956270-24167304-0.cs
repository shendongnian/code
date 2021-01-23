    public class DerivedClass : BaseClass
    {
       public DerivedClass(): base() // No harm done, but this is redundant
       {}
       //same as
       public DerivedClass()
       {}
    }
