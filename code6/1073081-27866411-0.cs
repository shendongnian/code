    public class ItemToVisibilityConverter : DependencyObject, IValueConverter
    {
        public IList Items
        {
            get { return (IList )GetValue(ItemsProperty); }
            set { SetValue(ItemsProperty, value); }
        }
        public static readonly DependencyProperty ItemsProperty=
            DependencyProperty.Register("Items", typeof(IList), typeof(ItemToVisibilityConverter), new PropertyMetadata(null));
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool hide = Items != null 
                && value != null 
                && Items.IndexOf(value) == Items.Count - 1;
            return (hide ? Visibility.Collapsed : Visibility.Visible);
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException;
        }
    }
