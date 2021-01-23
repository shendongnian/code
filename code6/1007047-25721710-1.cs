    using System;
    namespace ConsoleApplication1
    {
       class Program
       {
         static void Main(string[] args)
         {
            DoWorkA(DoWorkFinished);
            Console.Read();
         }
        private static void DoWorkA(Action whatToDoWhenFinished)
        {
            Console.WriteLine("Doing something");
            whatToDoWhenFinished();
        }
        private static void DoWorkFinished()
        {
            Console.WriteLine("Doing something Else");
        }
     }
    }
