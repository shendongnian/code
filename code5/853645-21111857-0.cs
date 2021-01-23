    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    
        {
            if (value == null) { return "White"; }
            var valueAsString = (string)value;
        
            if ( String.IsNullOrWhiteSpace(valueAsString) )
            {
                return "White";
            }
                   
            if (valueAsString.ToLower().Contains("Late".ToLower()))
            {
                return "Yellow";
            }
            return "White";         
        }
