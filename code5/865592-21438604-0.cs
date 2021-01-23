    [ValueConversion(typeof(ExpiryOptions), typeof(string))]
    public class MyEnumConverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            ExpiryOptions option= 
                (ExpiryOptions)Enum.Parse(typeof(ExpiryOptions),value.ToString());
            // Now that you have the value of the option you can use the culture info 
            // to change the value as you wish and return the changed value.
            return option.ToString();           
        }
    }
