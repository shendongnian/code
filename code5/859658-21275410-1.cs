    public static int UnsignificantDigits(Decimal value) {
      int result = 0;
      String St = value.ToString(CultureInfo.InvariantCulture);
      for (int i = St.IndexOf('.') + 1; i < St.Length && St[i] == '0'; ++i)
        result += 1;
      return result;
    }
  
    ...
    int count = UnsignificantDigits(0.000m); // <- returns 3
