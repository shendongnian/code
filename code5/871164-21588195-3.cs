    public class FileToUIElementConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string path = parameter.ToString();
    
            StreamResourceInfo sri = Application.GetResourceStream(new Uri(path, UriKind.Relative));
            if (sri != null)
            {
                using (Stream stream = sri.Stream)
                {
                    var logo = XamlReader.Load(stream) as DrawingImage;
    
                    if (logo != null)
                    {
                        return logo;
                    }
                }
            }
    
            throw new Exception("Resource not found");
        }
    
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
