    struct InfinityInt
    {
      readonly int Value;
      InfinityInt(int value, bool allowInfinities)
      {
        if (!allowInfinities && (value == int.MinValue || value == int.MaxValue))
          throw new ArgumentOutOfRangeException("value");
        Value = value;
      }
      public InfinityInt(int value)
        : this(value, false)
      {
      }
      public static InfinityInt PositiveInfinity = new InfinityInt(int.MaxValue, true);
      public static InfinityInt NegativeInfinity = new InfinityInt(int.MinValue, true);
      public bool IsAnInfinity
      {
        get { return Value == int.MaxValue || Value == int.MinValue; }
      }
      public override string ToString()
      {
        if (Value == int.MinValue)
          return double.NegativeInfinity.ToString();
        if (Value == int.MaxValue)
          return double.PositiveInfinity.ToString();
        return Value.ToString();
      }
      public static explicit operator int(InfinityInt ii)
      {
        if (ii.IsAnInfinity)
          throw new OverflowException();
        return ii.Value;
      }
      public static explicit operator double(InfinityInt ii)
      {
        if (ii.Value == int.MinValue)
          return double.NegativeInfinity;
        if (ii.Value == int.MaxValue)
          return double.PositiveInfinity;
        return ii.Value;
      }
      public static explicit operator InfinityInt(int i)
      {
        return new InfinityInt(i); // can throw
      }
      public static explicit operator InfinityInt(double d)
      {
        if (double.IsNaN(d))
          throw new ArgumentException("NaN not supported", "d");
        if (d >= int.MaxValue)
          return PositiveInfinity;
        if (d <= int.MinValue)
          return NegativeInfinity;
        return new InfinityInt((int)d);
      }
      static InfinityInt FromLongSafely(long x)
      {
        if (x >= int.MaxValue)
          return PositiveInfinity;
        if (x <= int.MinValue)
          return NegativeInfinity;
      
        return new InfinityInt((int)x);
      }
      public static InfinityInt operator +(InfinityInt a, InfinityInt b)
      {
        if (a.IsAnInfinity || b.IsAnInfinity)
        {
          if (!b.IsAnInfinity)
            return a;
          if (!a.IsAnInfinity)
            return b;
          if (a.Value == b.Value)
            return a;
          throw new ArithmeticException("Undefined");
        }
        return FromLongSafely((long)a.Value + (long)b.Value);
      }
      public static InfinityInt operator *(InfinityInt a, InfinityInt b)
      {
        if (a.IsAnInfinity || b.IsAnInfinity)
        {
          if (a.Value == 0 || b.Value == 0)
            throw new ArithmeticException("Undefined");
          return (a.Value > 0) == (b.Value > 0) ? PositiveInfinity : NegativeInfinity;
        }
        return FromLongSafely((long)a.Value * (long)b.Value);
      }
      // and so on, and so on
    }
