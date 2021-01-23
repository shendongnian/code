    public class SelectedItemColorConverter:IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
    
                
                if ((bool)value)
                {
                    return new SolidColorBrush((Colors.Red);
                }
                return new SolidColorBrush(Colors.White);
            }
    
            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                
               return null;
            }
        }
