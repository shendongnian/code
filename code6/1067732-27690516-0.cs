    class Base
    {
       int i = 1;
    }
    public class SubDerived : Base
    {
       public void f()
       {
            Console.WriteLine(base.i);
       }
    }
