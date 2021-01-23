     abstract class A { public string val { get; set; } }
    class B :  A
    {
      public int val {get;private set;}
    }
    class C :  A
    {
      public double val {get;private set;}
    }
    class D :  A
    {
      public string val {get;private set;}
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<object> list = new List<object> { new B(), new C(), new D() };
          // ... 
          foreach (A item in list)
          {
            Console.WriteLine(String.Format("Value is: {0}", item.val));
          }
        }
    }
