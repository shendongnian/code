        public object Convert(object value, Type targetType,
                              object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                if (parameter.ToString() == "02")
                {
                    return value.ToString() + " Starting";
                }
                else
                {
                    return value.ToString() + " Finishing";
                }
            }
            return String.Empty;
        }
