    using System;
    internal interface I {
      void Increment();
    }
    struct S : I {
      public readonly int Value;
      public S(int value) { Value = value; }
      public void Increment() {
        this = new S(Value + 1); // pure evil :O
      }
      public override string ToString() {
        return Value.ToString();
      }
    }
    class Program {
      static void Main() {
        object s = new S(123);
        ((I) s).Increment();
        Console.WriteLine(s); // prints 124
      }
    }
