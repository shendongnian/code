    public static class ButtonExt
    {
        public static readonly DependencyProperty VisibilityProperty;
        public static void SetVisibility(DependencyObject DepObject, Visibility value)
        {
            DepObject.SetValue(VisibilityProperty, value);
        }
        public static Visibility GetVisibility(DependencyObject DepObject)
        {
            return (Visibility)DepObject.GetValue(VisibilityProperty);
        }
        static ButtonExt()
        {
            PropertyMetadata VisibiltyPropertyMetadata = new PropertyMetadata(Visibility.Collapsed);
            VisibilityProperty = DependencyProperty.RegisterAttached("Visibility",
                                                                typeof(Visibility),
                                                                typeof(ButtonExt),
                                                                VisibiltyPropertyMetadata);
        }
    }
