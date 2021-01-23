    class MyMultiValueConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var firstRadioButtonValue = (bool)values[0];
            var comboBoxSelectedValue = values[1];
            return firstRadioButtonValue ? comboBoxSelectedValue : "MyStaticValue";
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
