    [ValueConversion(typeof(yourPropType), typeof(bool))]
    public class hiddenConverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (hideRow == "Yes")
            {
               return true;
            }
            else
            {
               return false;
            }
        }
    
   
    }
