    public class NullToVisibilityConverter : IValueConverter
    {
       public object Convert(...)
       {
           return value != null ? Visibility.Visible : Visibility.Collapsed;
       }
    
       public object ConvertBack(...)
       {
           return Binding.DoNothing;
       }
    }
