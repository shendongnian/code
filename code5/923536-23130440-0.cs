    public class DiscardingConverter : IValueConverter
    {
        public object Convert(...)
        {
            return DependencyObject.UnsetValue;
        }
    }
