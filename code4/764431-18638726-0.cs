    public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
                if (value is DateTime)
                {
                string date=value.Date.ToShortDateString();
                return (date);
                }
    
                 return string.Empty;
    }
       
