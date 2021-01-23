    public void Foo()
    {       
       var a = new A(1,2);
       //The 1 and 2 values can safely be removed from memory here.
    }
    public class A
    {
       int _a;
       int _b;
       public A(int a, int b)
       {
          _a = a;
          _b = b;
       }
    }
