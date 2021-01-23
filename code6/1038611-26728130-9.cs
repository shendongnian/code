    public class SharedFunctionality
    {
      public void DoStuff1()
      {
        // common implementation for do stuff 1
      }
      public void DoStuff2()
      {
        // common implementation for do stuff 2
      }
    }
    public class MyClass1
    {
      private readonly SharedFunctionality sharedFunctionality;
      public MyClass1()
      {
        this.sharedFunctionality = new SharedFunctionality();
      }
      public MyClass1 Method1()
      {
        this.sharedFunctionality.DoStuff1();
        return this;
      }
      public MyClass1 Method2()
      {
        this.sharedFunctionality.DoStuff2();
        return this;
      }
    }
    public class MyClass2
    {
      private readonly SharedFunctionality sharedFunctionality;
      public MyClass2()
      {
        this.sharedFunctionality = new SharedFunctionality();
      }
      public MyClass2 Method1()
      {
        this.sharedFunctionality.DoStuff1();
        return this;
      }
      public MyClass2 Method2()
      {
        this.sharedFunctionality.DoStuff2();
        return this;
      }
      public MyClass2 Method3()
      {
        // do something only this class does
        return this;
      }
    }
    class Program
    {
      static void Main(string[] args)
      {
        MyClass1 c1 = new MyClass1();
        c1.Method1().Method2();
        MyClass2 c2 = new MyClass2();
        c2.Method1().Method2().Method3();
      }
    }
