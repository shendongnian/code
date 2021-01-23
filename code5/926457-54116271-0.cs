    public class DecimalConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                string s_value = value.ToString();
                if (s_value.EndsWith("."))
                {
                    return s_value.Replace(".", ".0");
                }
                else if (s_value.Contains(".") && s_value.EndsWith("0"))
                {
                    return s_value.Substring(0, s_value.Length - 1);
                }
                return value;
            }
            return null;
        }
    }
        
    <TextBox>
        <Binding Path="UnitCost" UpdateSourceTrigger="PropertyChanged" Converter="{StaticResource decimalConverter}"/>
    </TextBox>
