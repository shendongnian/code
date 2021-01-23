      public object Convert(object[] values, Type targetType,
               object parameter, System.Globalization.CultureInfo culture)
        {
            try
            {
                if (((Content)values[0]).Type == "movie")
                {
                    return ((Content)values[0]).Movie.Language;
                }
                else
                    return ((Content)values[0]).Video.Language;
            }
            catch (Exception e)
            { return "EXception"; }
        }
        public object[] ConvertBack(object value, Type[] targetTypes,
               object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException("Cannot convert back");
        }
