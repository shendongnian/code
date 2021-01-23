    public class NumberToCheckedConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter,     System.Globalization.CultureInfo culture)
            {
                if ((int)value >= 5)
                    return true;
                return false;
            }
    
           public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
           {
               return Binding.DoNothing; //Null would cause an error on a set back.
           }
    }
