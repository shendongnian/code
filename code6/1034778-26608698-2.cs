    public class MultiCultureNumberConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, 
                              System.Globalization.CultureInfo culture)
        {
            var ci = System.Globalization.CultureInfo.InvariantCulture.Clone() 
                     as System.Globalization.CultureInfo;
            ci.NumberFormat.NumberDecimalSeparator = ",";
            return ((decimal)value).ToString(ci);
        }
        public object ConvertBack(object value, Type targetType, object parameter, 
                                  System.Globalization.CultureInfo culture)
        {
            var ci = System.Globalization.CultureInfo.InvariantCulture.Clone() as 
                     System.Globalization.CultureInfo;
            var s = System.Convert.ToString(value);
            decimal d;
            if (decimal.TryParse(s, System.Globalization.NumberStyles.Number 
                      ^ System.Globalization.NumberStyles.AllowThousands, ci, out d))
            {
                return d;
            }
            else
            {
                ci.NumberFormat.NumberDecimalSeparator = ",";
                if (decimal.TryParse(s, System.Globalization.NumberStyles.Number 
                    ^ System.Globalization.NumberStyles.AllowThousands, ci, out d)) 
                  return d;
            }
            return Binding.DoNothing;
        }
    }
