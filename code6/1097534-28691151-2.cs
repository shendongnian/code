    using System;
    
    namespace ConsoleApplication4
    {
      using System.Collections.ObjectModel;
    
      public class Program
      {
        static unsafe Collection<string> list = new Collection<string>();
    
        static unsafe void Main(string[] args)
        {
          for (int i = 1; i <= 10; i++)
          {
            Add(GetStr());
          }
    
          foreach (var str in list)
          {
            fixed (char* ptr = str)
            {
              var addr = (IntPtr)ptr;
              Console.WriteLine(addr.ToString("x"));
            }
          }
    
          Console.WriteLine("hmmmmmmmm");
          Console.ReadLine();
        }
    
        public unsafe static string GetStr()
        {
          return "OK";
        }
    
        public unsafe static void Add(string str)
        {
          list.Add(str);
        }
      }
    }
