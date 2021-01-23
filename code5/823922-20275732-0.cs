        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            DateTime dt = new DateTime();
            if (DateTime.TryParse(value.ToString(), out dt))
            {
                return "it's a date";
            }
            else
            {
                return "not a date";
            }
        }
