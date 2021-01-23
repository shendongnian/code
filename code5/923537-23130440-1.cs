    public class DiscardingConverter : IValueConverter
    {
        public object Convert(...)
        {
            return DependencyProperty.UnsetValue;
        }
    }
