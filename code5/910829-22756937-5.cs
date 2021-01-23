    public class ConvertToFormatedRuns : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var tb = new TextBlock();
    
            tb.Inlines.Add(new Run() { Text = (string)values[0], Background = Brushes.Yellow });
            tb.Inlines.Add(new Run() { Text = (string)values[1]});
    
            return tb;
        }
    }
