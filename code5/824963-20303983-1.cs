    class ArtistsListConverter : IValueConverter
    {
        public object Convert(
            object value, Type targetType, object parameter, CultureInfo culture)
        {
            object result = null;
            var artists = value as IEnumerable<Artist>;
            if (artists != null)
            {
                result = string.Join(", ", artists.Select(a => a.Name));
            }
            return result;
        }
        public object ConvertBack(
            object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
