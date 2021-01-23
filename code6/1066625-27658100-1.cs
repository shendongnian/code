    public class ChangeConverter: IMultiValueConverter
        {
            public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                try
                {
                    double par1 = double.Parse(values[0].ToString());
                    double par2 = double.Parse(values[1].ToString());
                    double res = par2 - par1;
                    return res.ToString();
                }
                catch (Exception)
                {
                    return null;
                }
            }
    
            public object[] ConvertBack(object value, Type[] targetTypes,
                   object parameter, System.Globalization.CultureInfo culture)
            {
                throw new NotSupportedException("Cannot convert back");
            }
        }
