    [ValueConversion(typeof(MyEnum), typeof(String))]
    public class MyEnumConverter : IValueConverter
    {
        public object Convert(object value,
            Type targetType,
            object parameter,
            CultureInfo culture)
        {
            var enumVal = (MyEnum)value;
            // in this example, this is an extension method
            return enumValue.Description();
        }
    
        public object ConvertBack(object value,
            Type targetType,
            object parameter,
            CultureInfo culture)
        {
            var enumDesc = value as string;
            MyEnum val;
            if (Enum.TryParse(typeof(MyEnum), strValue, out val))
            {
                return val;
            }
            return DependencyProperty.UnsetValue;
        }
    }
