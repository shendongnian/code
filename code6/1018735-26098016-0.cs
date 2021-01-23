    public class ProgressBarExtension
    {
        public static readonly DependencyProperty ProgressBarBrushProperty =
            DependencyProperty.RegisterAttached("ProgressBarBrush",
            typeof(Brush), typeof(ProgressBarExtension),
            new PropertyMetadata(null, OnProgressBarBrushChanged));
    
        public static void SetProgressBarBrush(UIElement element, object value)
        {
            element.SetValue(ProgressBarBrushProperty, value);
        }
    
        public static object GetProgressBarBrush(UIElement element)
        {
            return element.GetValue(ProgressBarBrushProperty);
        }
    
        private static void OnProgressBarBrushChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            App.Current.Resources["ProgressBarIndeterminateForegroundThemeBrush"] = args.NewValue as SolidColorBrush;
        }
    }
