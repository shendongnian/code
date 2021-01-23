    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
            {
                //if Detail or Solution is not null,not empty and not UnsetValue than show control 
                if (values.Any(v => v is string && !string.IsNullOrEmpty(v.ToString()))) return Visibility.Visible;
                return Visibility.Collapsed;
            }
