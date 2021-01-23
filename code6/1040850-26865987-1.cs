    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string strValue = System.Convert.ToString(value);
            DateTime resultDateTime;
            if (DateTime.TryParse(strValue, out resultDateTime))
            {
                return resultDateTime;
            }
            return value;    
        }
