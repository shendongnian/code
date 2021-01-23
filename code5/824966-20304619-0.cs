    public class ArtistsToStringConverter : System.Windows.Data.IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var artists = value as IEnumerable<Artist>;
            if (artists != null)
            {
                var artistNames = from artist in artists select artist.Name;
                return string.Join(", ", artistNames);
            }
            return null;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
