     [ValueConversion(typeof(Enum), typeof(bool))]
     public class EnumToBooleanConverter : IValueConverter
     {
       public object Convert(object value,
                          Type targetType,
                          object parameter,
                          CultureInfo culture)
           {
             if (
                 (value == null) 
                 || 
                 (!(value is Enum))
                 ||
                 (parameter == null)
                 )
                    {
                       return false;
                    }
      foreach (Enum paramValue in ParseObjectToEnum(value.GetType(),
                                                    parameter))
      {
        if (value.Equals(paramValue))
        {
          return true;
        } 
      }
      return false;
    }
   
    public object ConvertBack(object value,
                              Type targetType,
                              object parameter,
                              CultureInfo culture)
    {
      object result = Binding.DoNothing;
     
      if ((bool)value)
      {
        Enum[] parsedValues = ParseObjectToEnum(targetType,
                                                parameter);
        if (parsedValues.Length > 0)
        {
          result = parsedValues[0];
        } 
      }
      return result;
    } 
   
    private static Enum[] ParseObjectToEnum(Type enumType,
                                            object value)
    {
      var enumValue = value as Enum;
      if (enumValue != null)
      {
        return new[] { enumValue };
      }
      var str = value as string;
      if (string.IsNullOrEmpty(str))
      {
        throw new ArgumentException("parameter");
      }
      string[] strArray = str.Split(new[] { ';', ',' },
                                    StringSplitOptions.RemoveEmptyEntries);
      var enumArray = new Enum[strArray.Length];
      for (int i = 0;
           i < strArray.Length;
           i++)
      {
        enumArray[i] = (Enum)Enum.Parse(enumType,
                                        strArray[i],
                                        true);
      }
      return enumArray;
    } 
