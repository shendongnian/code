    public class runme {
      static void Main() 
      {
        System.Console.WriteLine("Running");
        using (Foo myFoo = new CSharpDerived())
        {
          test.test_catch(myFoo);
        }
      }
    }
