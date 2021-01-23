    public abstract class A
    {
       public void Method1()
       {
         //method code
       }
    
       public abstract void Method2();
    
       public virtual void Method3()
       {
        //method code for class A, when class A calls Method3, this code is executed
       }
    }
    
    public class B : A
    {
       public override void Method2()
       {
         //this must be implemented here to use it
       }
    
       public override void Method3()
       {
         //method code for class B, when class B calls Method3, this code is executed
         //or, if you choose not to override this method, the compiler will use the code in class A
       }
    }
