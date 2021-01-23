    public class OuterboundsConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            Visibility vis = Visibility.Visible;
            
            
            if (values != null)
            {
                ObservableCollection<string> steps = values[0] as ObservableCollection<string>;
                string item = values[1] as string;
                if (steps != null && item != null)
                {
                    if (steps.Count > 0)
                    {
                        if (steps[0] == item || steps[steps.Count - 1] == item)
                        {
                            vis = Visibility.Collapsed;
                        }
                    }
                }
            }
            return vis;
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
