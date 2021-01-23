    sealed class StockColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            // Convert a delta value to a brush color.
            var deltaValue = System.Convert.ToDecimal(value);
            if (deltaValue > 0)
                return Brushes.Green;       // Positive
            else if (deltaValue < 0)
                return Brushes.Red;         // Negative 
            else
                return Brushes.Black;       // Zero
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            // We can't convert a color to a delta value! This will never be used anyhow.
            throw new NotSupportedException();
        }
    }
