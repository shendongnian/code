    public class BackGroundConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var day = value as Day;
            if (day != null)
            {
                //Dont use else if Like Saturday can be a restricted holiday so gray needs to be overridden by red.
                if (day.HolidayType == HolidayType.SatOrSun)
                    return new SolidColorBrush(Colors.Gray);
                if (day.HolidayType == HolidayType.RestrictedHoliday)
                    return new SolidColorBrush(Colors.Red);
                if (day.HolidayType == HolidayType.PublicHoilday)
                    return new SolidColorBrush(Colors.Blue);
            }
            return null;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
