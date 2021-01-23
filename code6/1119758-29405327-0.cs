    public interface IPerson
    {
      void Method1();
      void Method2(int i);
    }
    public class concrete : IPerson
    { 
       public void Method1()
       { 
         Console.WriteLine("Concrete");
       }
       public void Method2(int i)
       { 
         Console.WriteLine("Concrete");
       }
    }
