    struct XNumber {
      private enum SpecialValue { Normal, Negative, Infinity}
      private int value;
      private SpecialValue kind;
    
      public XNumber Infinity = new XNumber { kind = SpecialValue.Infinity };
      public XNumber Negative = new XNumber { kind = SpecialValue.Negative };
    
      public static implicit operator XNumber(int value) {
        if (value < 0)
          return new XNumber { kind = SpecialValue.Negative };
        return new XNumber { value = value };
      }
    
      // ...
    }
