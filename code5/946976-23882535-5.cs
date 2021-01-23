    class Extras: DependencyObject
    {
        public static Brush GetIcon(DependencyObject obj)
        {
            return (Brush)obj.GetValue(IconProperty);
        }
        public static void SetIcon(DependencyObject obj, Brush value)
        {
            obj.SetValue(IconProperty, value);
        }
        // Using a DependencyProperty as the backing store for Icon.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IconProperty =
            DependencyProperty.RegisterAttached("Icon", typeof(Brush), typeof(Extras), new PropertyMetadata(null));
    }
