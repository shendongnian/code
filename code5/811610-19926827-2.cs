    public class GroupSizeToExpanderConverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            CollectionViewGroup grp = (CollectionViewGroup)value;
            return grp.Items.Count() > 0; // ALTERNATIVLY grp.ItemCount;             
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
        
