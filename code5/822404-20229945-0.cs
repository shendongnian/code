    public class UserIdToNameConverter : DependencyObject, IValueConverter
    {
        public string StoreId
        {
            get { return (string) GetValue(StoreIdProperty); }
            set { SetValue(StoreIdProperty, value); }
        }
        public static readonly DependencyProperty StoreIdProperty =
            DependencyProperty.Register("StoreId",
                                        typeof (string),
                                        typeof (UserIdToNameConverter),
                                        new PropertyMetadata(string.Empty));
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            //Your current code
            //Can now use StoreId instead of ConverterParameter
        }
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            //Same as above;
        }
    }
