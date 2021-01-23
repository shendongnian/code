    public abstract void RefreshDisplay<TView, TEnum>(TEnum value)
        where TEnum : struct,  IComparable, IFormattable, IConvertible
    {
      if (!typeof(TEnum).IsEnum) { throw new ArgumentException("TEnum must be an enumerated type"); }
     //Implementation goes here
     
    }
