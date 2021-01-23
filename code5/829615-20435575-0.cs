    public abstract class A1
    {
      //shared things for A and B 
    
      public string Hello()
      {
         return "hello!";
      }
    }
    
    public class A : A1
    {
    
    }
    
    public class B : A1
    {
    
    }
    
    public void something(A foo)
    {
       var bar = ((A1)foo).Hello(); // says hello
    }
