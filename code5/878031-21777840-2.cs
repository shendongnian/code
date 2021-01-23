    class HasChangedConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var shipment = value as Shipment;
            var property = parameter as string;
            return new SolidColorBrush(shipment.HasChanged(property));
        }
    }
