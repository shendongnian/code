    public class CarMakeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, 
            object parameter, CultureInfo culture)
        {
            var input = (List<CarMakes>)value;
            return input.SelectMany(carMake=> carMake.Cars);
        }
     
        public object ConvertBack(object value, Type targetType, 
            object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
