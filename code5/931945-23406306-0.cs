    public class AppBarButton
    {
        public static string GetImage(DependencyObject obj)
        {
            return (string)obj.GetValue(ImageProperty);
        }
    
        public static void SetImage(DependencyObject obj, string value)
        {
            obj.SetValue(ImageProperty, value);
        }
    
        public static readonly DependencyProperty ImageProperty =
            DependencyProperty.RegisterAttached("Image", typeof(string), typeof(AppBarButton), new PropertyMetadata(string.Empty));
    }
