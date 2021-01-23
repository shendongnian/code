    public class A
    {
      public B b;
      
      public A()
      {
        b = new B(this);
      }
    }
    
    public class B
    {
      public A a;
    
      public B(A _a)
      {
        a = _a;
      }
    }
