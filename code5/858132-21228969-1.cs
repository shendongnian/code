    public class A
    {
       private B _b;
    
       public A(B b)
       {
          _b = b;
          _b.SomethingHappened += SomethingHappenedWithB; // subscribe
       }
    
       private void SomethingHappenedWithB(int data)
       {
           // handle event, use data
       }
    }
