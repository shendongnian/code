    struct MyFunctions {
      public Func<int,string,bool> ptr1;
      public Action<int> ptr2;
    }
    class Program
    {
      static void Main(string[] args)
      {
         MyFunctions sample = new MyFunctions() { ptr1 = TestValues, ptr2 = DoThing };
         sample.ptr1(42, "Answer");
         sample.ptr2(100);
      }
      static bool TestValues(int a, string b)
      {
         Console.WriteLine("{0} {1}", a, b);
         return false;
      }
      static void DoThing(int a)
      {
         Console.WriteLine("{0}", a);
      }
    }
