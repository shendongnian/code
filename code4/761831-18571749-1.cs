    ///comment the method assumptions here
    ///otherwise the method might seem wrong
    public static double GetNumber(string numberString)
    {
       bool hasDecimalComma = numberString.Contains(',');
       if (hasDecimalComma)
         numberString = numberString.Replace(',', '.')
       double result;
       bool success = double.TryParse(numberString, 
                          NumberStyles.Float, 
                          CultureInfo.InvariantCulture,
                          out result);
       if (success)
         return result;
       else 
         throw new ArgumentException(
                               string.Format("can't parse '{0}'", numberString));
    }
