    class ExtraProperties: DependencyObject
    {
        public static Visual GetIcon(DependencyObject obj)
        {
            return (Visual)obj.GetValue(IconProperty);
        }
        public static void SetIcon(DependencyObject obj, Visual value)
        {
            obj.SetValue(IconProperty, value);
        }
        // Using a DependencyProperty as the backing store for Icon.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IconProperty = DependencyProperty.RegisterAttached("Icon", typeof(Visual), typeof(ExtraProperties), new PropertyMetadata(null));
    }
