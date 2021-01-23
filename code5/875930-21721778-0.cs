    public static class Popup
    {
        #region Popup Background Property
        public static readonly DependencyProperty BackgroundProperty;
        public static void SetBackground(DependencyObject DepObject, Brush value)
        {
            DepObject.SetValue(BackgroundProperty, value);
        }
        public static Brush GetBackground(DependencyObject DepObject)
        {
            return (Brush)DepObject.GetValue(BackgroundProperty);
        }
        #endregion
        static Popup()
        {
            #region Popup Background Registration
            PropertyMetadata BrushPropertyMetadata = new PropertyMetadata(Brushes.Transparent);
            BackgroundProperty = DependencyProperty.RegisterAttached("Background",
                                                             typeof(Brush),
                                                             typeof(Popup),
                                                             BrushPropertyMetadata);
            #endregion
        }
    }
