    public class MyConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter,
                               System.Globalization.CultureInfo culture)
        {
            var parentList = value as ObservableCollection<Parent>;
            var childCollection = new ObservableCollection<Children>();
            if (parentList != null)
            {
                childCollection = new ObservableCollection<Children>
                                     (parentList.SelectMany(p => p.Childrens));
            }
            return childCollection;
        }
        public object ConvertBack(object value, Type targetType, object parameter, 
                                    System.Globalization.CultureInfo culture)
        {
           return Binding.DoNothing;
        }
    }
