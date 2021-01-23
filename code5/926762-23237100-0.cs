    class MyClass
    {
      public override bool Equals(object obj)
      {
          Console.WriteLine("My Class Equals is called");
          return true;
      }
    }
    
    void Main()
    {
       object a = new MyClass();
       object b = new MyClass();
       Console.WriteLine (a.Equals(b));
    }
