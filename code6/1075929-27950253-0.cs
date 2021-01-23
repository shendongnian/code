    public class BoolToVisibilityConverter : IValueConveter
    {
        public object Convert (...)
        {
            return ((bool)value) ? Visibility.Visible : Visibility.Collapsed
        }
        public object ConvertBack(...)
        {
             return Binding.DoNothing; //Or you could do the backwards conversion if you want
        }
    }
