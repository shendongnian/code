    class MyValue {
    
      public int Value { get; private set; }
    
      public MyValue(int value) {
        Value = value;
      }
    
      public static MyValue operator ++(MyValue v) {
        v.Value++;
        return v;
      }
    
    }
    
    class MyClass {
    
      private MyValue _count = new MyValue(0);
    
      public MyValue Count {
        get { return _count; }
        set { }
      }
    
    }
