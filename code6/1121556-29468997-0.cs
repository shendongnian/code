    namespace Test1
    {
       public static class ABC
       {
         public const string AC = "Account";
       } 
    }
    using Test1;
    namespace ConsoleApplication1
    {
       class Program
       {
          static void Main(string[] args)
          {
             Console.WriteLine( ABC.AC);
          }
       }
    }
