    public class A : IA
    {
           public void DoSomething(long x)
            {
               }
    }
    
    public interface IA
    {
         void DoSomething(long x)
    }
    
    
    /*Some method somewhere*/
    public void DoThisThing()
    {
       IA a = new A();
    
       a.DoSomething(10);
    }
