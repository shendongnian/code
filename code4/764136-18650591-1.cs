    public class SponsorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Assuming that you have the sponsor's name as string as follows: 
            var sn = SponseredName.ToString();
            
            if (sn.Equals("A"))
               return Visibility.Visible;
            elseif () ...
            return Visibility.Collapsed;
        }
    
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Visibility.Collapsed;
        }
    }
