        public class DynamicValuesConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
                switch (value.ToString())
                {
                    case "Based On Injection Rate":
                        return new[] { "kg/m3", "gm/cm3" };
                    case "Based On Viscosity":
                        return new[] { "some other..." };
                }
            return new string[0];
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
