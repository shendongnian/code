    public class ImageConverter: MarkupExtension, IValueConverter
    {
        public ImageConverter()
        {
        }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return new BitmapImage();
            var task = Task.Run(() =>
            {
                Thread.Sleep(5000); // Perform your long running operation and request here
                return value.ToString();
            });
            return new TaskCompletionNotifier<string>(task);
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }
