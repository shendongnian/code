    public class ObservableToGroupedConverter : IValueConverter
    {
        public object Convert(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            var group = (value as ViewModelFriends).friends;
            return metodosAuxiliares.GetItemGroups(group.OrderBy(o => o.distraw).ToList(), c => c.online);
        }
        public object ConvertBack(object value, Type targetType,
           object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
