    namespace Example
    {
       class Program
       {
          public class ClassInPublic
          {
              static public int Num;
              static public string Sentence;
          }
    
          ClassInPublic DeclaringInstance = new ClassInPublic();
    
          private static void Foo()
          {
              ClassInPublic.Num = 35;
              ClassInPublic.Sentence = "Hello World";
              Console.WriteLine("This Private Function! And Assign Variable Value From ClassInPublic Variable");
          }
    
          private static void Foo2()
          {
              Console.Write("This Single Foo didnt have any Instance Class\n");
          }
    
          public static int Main(string[] args)
          {
              Foo();
              return 0;
          }
       }
    }
