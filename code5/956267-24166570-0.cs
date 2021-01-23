    public class BaseClass
    {
      public BaseClass(int number)
      {
         // DoSomething
      }
      
      public BaseClass(string str)
      {
        // Do Something
      }
    }
    
    public class DerivedClass : BaseClass
    {
       public DeriveClass(): base(7){} 
       public DeriveClass(string str) : base(str){}
    }
