     public class BrushColorConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                if ((bool)value)
                {
                    {
                        return System.Windows.Media.Colors.Gray;
                    }
                }
                return System.Windows.Media.Colors.Black;
            }
        
            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        
        }
