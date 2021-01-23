    public class NotePitchConverter : IValueConverter
    {
        private const double radius = 1.5;
        private const double distance = 2 * radius + 1;
        public object Convert(
            object value, Type targetType, object parameter, CultureInfo culture)
        {
            var pitch = (int)value;
            var geometry = new GeometryGroup();
            if (parameter as string == "Bottom")
            {
                pitch = -pitch;
            }
            for (int i = 0; i < pitch; i++)
            {
                geometry.Children.Add(new EllipseGeometry(
                    new Point(radius, radius + i * distance), radius, radius));
            }
            return geometry;
        }
        public object ConvertBack(
            object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
