    class BaseClass
    {
        protected bool sharedMember;
    }
    
    class DerivedClassA : BaseClass
    {
       public DerivedClassA()
       {
          DerivedClassB otherObject = new DerivedClassB();
          otherObject.sharedMember = sharedMember; //Compiler error, cannot access protected member
       }
    }
    
    class DerivedClassB : BaseClass
    {
    }
