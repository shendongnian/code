    public class LinkTypeToBoolCvt : IValueConverter
    {
        #region | Members of IValueConverter |
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            // please refer to the implementation of "CallBack" method
            throw new NotImplementedException();
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null || parameter == null) return DependencyProperty.UnsetValue;
            var param= parameter.ToString();
            int result;
            if (int.TryParse(param,out result))
            {
                // ex: if the parameter is 11, the result will be "A|B|D"
                return result;
            }
            else
            {
                // ex: if the parameter is "A|E", the result will be 17
                var enums = param.Split(new []{"|"}, StringSplitOptions.RemoveEmptyEntries);
                LinkType lt = 0;
                LinkType ltTemp = 0;
                foreach (var item in enums)
                {
                    if (Enum.TryParse<LinkType>(item, out ltTemp)) lt |= ltTemp;
                }
                if (lt == 0) return DependencyProperty.UnsetValue;
                else return lt;
            }
        } 
        #endregion
    }
    
