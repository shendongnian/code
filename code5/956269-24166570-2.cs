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
       public DerivedClass(): base(7){} 
       public DerivedClass(string str) : base(str){}
    }
