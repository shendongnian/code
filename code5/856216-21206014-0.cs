    public static class ZoomBehavior
    {
        public static readonly DependencyProperty IsStartProperty;
        public static void SetIsStart(DependencyObject DepObject, bool value)
        {
            DepObject.SetValue(IsStartProperty, value);
        }
        public static bool GetIsStart(DependencyObject DepObject)
        {
            return (bool)DepObject.GetValue(IsStartProperty);
        }
        static ZoomBehavior()
        {
            IsStartMoveProperty = DependencyProperty.RegisterAttached("IsStart",
                                                                typeof(bool),
                                                                typeof(ZoomBehavior),
                                                                new UIPropertyMetadata(false, IsStart));
        }
        private static void IsStart(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            UIElement uiElement = sender as UIElement;
            if (uiElement != null)
            {
                if (e.NewValue is bool && ((bool)e.NewValue) == true)
                {
                    uiElement.MouseDown += new MouseButtonEventHandler(ObjectMouseDown);
                    uiElement.MouseMove += new MouseEventHandler(ObjectMouseMove);
                    uiElement.MouseUp += new MouseButtonEventHandler(ObjectMouseUp);
                }
            }
        }
        // Below is event handlers
    }
