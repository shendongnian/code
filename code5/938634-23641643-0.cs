    public class ResourceTranslationConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var valString = value as string;
    
            // If what is being converted is a string, return the resource translation
            // Else return something else, such as the object itself
            return valString == null ? value : ResourceController.GetString(valString);
        }
    
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
