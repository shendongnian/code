    class RectangleHelper : DependencyObject
    {
        public static Point GetLocation(DependencyObject obj)
        {
            return (Point)obj.GetValue(LocationProperty);
        }
        public static void SetLocation(DependencyObject obj, Point value)
        {
            obj.SetValue(LocationProperty, value);
        }
        // Using a DependencyProperty as the backing store for Location.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LocationProperty =
            DependencyProperty.RegisterAttached("Location", typeof(Point), typeof(RectangleHelper), new PropertyMetadata(new Point(), OnLocationChanged));
        private static void OnLocationChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Point newValue = (Point)e.NewValue;
            d.SetValue(Canvas.LeftProperty, newValue.X);
            d.SetValue(Canvas.TopProperty, newValue.Y);
        }
    }
