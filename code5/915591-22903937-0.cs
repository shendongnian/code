            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                return Convert(new[] { value }, targetType, parameter, culture);
            }
    
            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }
    
            public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
            {
                try
                {
                    string imageUri = String.Format((parameter ?? "{0}").ToString(), values);
                    return new BitmapImage(new Uri(imageUri, UriKind.RelativeOrAbsolute));
                }
                catch
                {
                    return null;
                }
            }
    
            public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }
