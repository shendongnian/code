    public class MyCustomProperty
    {
        #region Color dependency property
        public static readonly DependencyProperty ColorProperty;
        public static Color GetColor(DependencyObject obj)
        {
            return (Color)obj.GetValue(ColorProperty);
        }
        public static void SetColor(DependencyObject obj, Color value)
        {
            obj.SetValue(ColorProperty, value);
        }
        #endregion
        static MyCustomProperty()
        {
            //register attached dependency property
            var metadata = new FrameworkPropertyMetadata(Colors.Transparent);
            ColorProperty = DependencyProperty.RegisterAttached("Color",
                                                                typeof(Color),
                                                                typeof(MyCustomProperty), metadata);
        }
    }
