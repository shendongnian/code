    public sealed class MyFakeEnum {
    
      private MyFakeEnum(int value, string description) {
        Value = value;
        Description = description;
      }
    
      public int Value { get; private set; }
    
      public string Description { get; private set; }
    
      // Probably add equality and GetHashCode implementations too.
    
      public readonly static MyFakeEnum Value1 = new MyFakeEnum(1, "value1");
      public readonly static MyFakeEnum Value2 = new MyFakeEnum(2, "value2");
    }
