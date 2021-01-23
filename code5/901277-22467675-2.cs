    class Foo {
      private ThreadLocal<int> _internalState;
      public Foo() {
        _internalState = new ThreadLocal<int>();
      }
      public int IntValue {
        get { return _internalState.Value; }
        set { _internalState.Value = value; }
      }
      public override string ToString() {
        return _internalState.ToString();
      }
    }
  
    class Program {
      public static void Main(string[] args) {
        Demonstrate();
      }
      static void Demonstrate() {
        var local = new Foo {IntValue = 5};
        Console.WriteLine("Start thread value: {0}", local.IntValue);
        new Thread(() => {
          local.IntValue += 5;
          Console.WriteLine("New thread value: {0}", local.IntValue);
        }).Start();
        local.IntValue += 10;
        Console.WriteLine("Start thread value: {0}", local.IntValue);
      }
    }
