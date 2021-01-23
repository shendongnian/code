    class InternalItemConverter : IValueConverter
    {
        public LabeledComboBox LabeledComboBox { get; set; }
        public object Convert(
            object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (LabeledComboBox != null && LabeledComboBox.ItemConverter != null)
            {
                value = LabeledComboBox.ItemConverter.Convert(
                    value, targetType, parameter, culture);
            }
            return value;
        }
        public object ConvertBack(
            object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (LabeledComboBox != null && LabeledComboBox.ItemConverter != null)
            {
                value = LabeledComboBox.ItemConverter.ConvertBack(
                    value, targetType, parameter, culture);
            }
            return value;
        }
    }
