    struct MyStruct 
    {
      public readonly int I;
      public MyStruct(int i_initial)
      {
        I = i_initial;
      }
    }
    MyStruct j = new MyStruct(3);
    public static void StructMod(MyStruct ms)
    {
      Console.WriteLine(ms.I + 100);
    }
