    public class Test
    {
       public static void Main()
       {
          var b = new string[] {"One", "Two", "Three"};
          Console.WriteLine(Foo(b)); // Call Foo with an array
          Console.WriteLine(Foo("Four", "Five")); // Call Foo with parameters
       }
    	
       public static int Foo(params string[] test)
       {
          return test.Length;
       }
    }
