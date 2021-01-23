    [ValueConversion(typeof(string), typeof(ImageSource))]
    public class EmptyImageToImageSourceConverter : IValueConverter
    {
        /// <summary>
        /// Converts an empty string value into the DefaultImagePath property value if it exists, or a DependencyProperty.UnsetValue otherwise.
        /// </summary>
        public string DefaultImagePath { get; set; }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null || targetType != typeof(ImageSource)) return DependencyProperty.UnsetValue;
            string imagePath = value.ToString();
            return imagePath.IsNullOrEmpty() ? DefaultImagePath.IsNullOrEmpty() ? DependencyProperty.UnsetValue : DefaultImagePath : imagePath;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }
