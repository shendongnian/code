    public class OptimizedDoubleToStringConverter : ConverterBase
    {
       private double _prevValue;
    
       public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
       {
          if (!(value is double) && !(value is float))
             return null;
    
          return XMath.Eq(_prevValue, System.Convert.ToDouble(value))
                ? Binding.DoNothing
                : value.ToString();
       }
    
       public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
       {
          if (!(value is string))
             return null;
    
          double doubleValue = double.Parse(value.ToString());
    
          if (!XMath.Eq(_prevValue, doubleValue))
             _prevValue = doubleValue;
    
          return doubleValue;
       }
    }
