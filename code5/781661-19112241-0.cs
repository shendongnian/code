    public class StatusToColorConverter : IValueConverter
    {
        public Brush CancelledBrush { get; set; }
        public Brush DelayedBrush { get; set; }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var status = (Status)value;
            if (status.IsCancelled)
            {
                return this.CancelledBrush;
            }
            
            if (status.IsDelayed)
            {
                return this.DelayedBrush;
            }
            
            return parameter;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
