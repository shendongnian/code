    class DefinitelyNotThreadSafe {
      public int IntValue;
      public override string ToString() {
        return IntValue.ToString();
      }
    }
    class Program {
      public static void Main(string[] args) {
        Demonstrate(false);
      }
      static void Demonstrate(bool expose) {
        var local = new ThreadLocal<DefinitelyNotThreadSafe>(expose) {
          Value = new DefinitelyNotThreadSafe {IntValue = 5}
        };
        new Thread(() => {
          Console.WriteLine("Inside new thread...");
          try {
            local.Value.IntValue = 10;
          } catch (NullReferenceException) {
            Console.WriteLine("New thread's instance doesn't exist.");
          }
          local.Value = new DefinitelyNotThreadSafe {IntValue = 10};
          if (expose) {
            local.Values.ToList().ForEach(Console.WriteLine);
          }
          Console.WriteLine("New thread's value: {0}", local.Value);
          local.Value.IntValue = 15;
          Console.WriteLine("New thread's value: {0}", local.Value);
        }).Start();
        Console.WriteLine("Outside new thread...");
        if (expose) {
          local.Values.ToList().ForEach(Console.WriteLine);
        }
        Console.WriteLine("Start thread's value: {0}", local.Value);
      }
    }
