    public class DDSConverter : IValueConverter
    {
        private static readonly DDSConverter defaultInstace = new DDSConverter();
    
        public static DDSConverter Default
        {
            get
            {
                return DDSConverter.defaultInstace;
            }
        }
    
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }
            else if (value is Stream)
            {
                return DDSConverter.Convert((Stream)value);
            }
            else if (value is string)
            {
                return DDSConverter.Convert((string)value);
            }
            else if (value is byte[])
            {
                return DDSConverter.Convert((byte[])value);
            }
            else
            {
                throw new NotSupportedException(string.Format("{0} cannot convert from {1}.", this.GetType().FullName, value.GetType().FullName));
            }
        }
    
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException(string.Format("{0} does not support converting back.", this.GetType().FullName));
        }
    
        public static ImageSource Convert(string filePath)
        {
            using (var fileStream = File.OpenRead(filePath))
            {
                return DDSConverter.Convert(fileStream);
            }
        }
    
        public static ImageSource Convert(byte[] imageData)
        {
            using (var memoryStream = new MemoryStream(imageData))
            {
                return DDSConverter.Convert(memoryStream);
            }
        }
    
        public static ImageSource Convert(Stream stream)
        {
            ...
        }
    }
