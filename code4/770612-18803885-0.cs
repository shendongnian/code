    class BoxedInt2
    {
      public readonly int _value = 42;
      void PrintValue()
      {
        Console.WriteLine(_value);
      }
    }
    class Tester
    {
      BoxedInt2 _box = null;
      public void Set() {
        _box = new BoxedInt2();
      }
      public void Print() {
        var b = _box;
        if (b != null) b.PrintValue();
      }
    }
