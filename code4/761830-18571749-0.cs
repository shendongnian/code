    public static double GetNumber(string numberString, CultureInfo culture)
    {
       double result;
       bool success = double.TryParse(numberString, 
                              NumberStyles.Float | NumberStyles.AllowThousands, 
                              culture,
                              out result);
       if (success)
          return result;
       else 
          throw new ArgumentException(
                                   string.Format("can't parse '{0}'", numberString));
    }
