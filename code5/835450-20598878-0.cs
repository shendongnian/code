    [ValueConversion(typeof(double) ,typeof(string))]
    public class DoubleConverter : IValueConverter
    {
        public object Convert(object value ,Type targetType ,object parameter ,CultureInfo culture)
        {
            double doubleType = (double)value;
            return doubleType.ToString();
        }
    
        public object ConvertBack(object value ,Type targetType ,object parameter ,CultureInfo culture)
        {
            string strValue = value as string;
            double resultDouble;
            if ( double.TryParse(strValue ,out resultDouble) )
            {
                return resultDouble;
            }
            return DependencyProperty.UnsetValue;
        }
    }
