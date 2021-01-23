     public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                if (value.Equals(true)) 
                    return new Uri(@"C:\Users\pj827192\Desktop\Untitled.png");
                return new Uri(@"C:\Users\Public\Pictures\Sample Pictures\Hydrangeas.jpg");
            }
    
            public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                throw new NotImplementedException();
            }
