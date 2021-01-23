     public class YesNoToBooleanConverter : IValueConverter
        {
                public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
                {
                        if(value.ToString()=="0")
                          {
                             return false;
                          }
                        else
                         {
                            return true;
                         }
                }
                public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
                {
                       
                }
        }
