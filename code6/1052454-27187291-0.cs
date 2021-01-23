    static class Helper
    {
        public static object GetImage(DependencyObject obj)
        {
            return (object)obj.GetValue(ImageProperty);
        }
        public static void SetImage(DependencyObject obj, object value)
        {
            obj.SetValue(ImageProperty, value);
        }
        public static readonly DependencyProperty ImageProperty =
            DependencyProperty.RegisterAttached(
                "Image",
                typeof(object),
                typeof(Helper),
                new PropertyMetadata(null));
    }
