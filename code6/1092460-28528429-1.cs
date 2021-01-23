    public class ItemClickConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var icea = (ItemClickEventArgs)value;
            if (icea != null)
                return icea.ClickedItem;
            return null;
        }
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
