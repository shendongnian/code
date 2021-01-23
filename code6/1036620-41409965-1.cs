    public class TestConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            ItemsControl ctrl = parameter as ItemsControl;
            Label lbl = ctrl.Items[0] as Label;
            var c = lbl.Content;
            
            ...
        }
