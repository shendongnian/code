    public class BoolToMarginConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            //Get the passed in value and convert it to a boolean - the as keyword returns a null if we can't convert to a boolean so the ?? allows us to set a default value if we get a null instead
            bool isSubItem = (value as bool?) ?? false;
            // If the item IS a sub item, we want a larger Left Margin
            // Since the Margin Property expects a Thickness, that's what we need to return
            return new Thickness(isSubItem == true ? 24 : 12, 0, 0, 0);
        }
        // This isn't necessary in most cases, and in this case can be ignored (just required for the Interface definition)
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
