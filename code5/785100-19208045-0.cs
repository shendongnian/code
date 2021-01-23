    public static class PanelBehaviors
    {
        public static void SetIsSliding(DependencyObject target, bool value)
        {
            target.SetValue(IsSlidingProperty, value);
        }
        public static readonly DependencyProperty IsSlidingProperty =
                                                  DependencyProperty.RegisterAttached("IsSliding",
                                                  typeof(bool),
                                                  typeof(PanelBehaviors),
                                                  new UIPropertyMetadata(false, OnIsSliding));
        private static void OnIsSliding(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue is bool && ((bool)e.NewValue) == true)
            {
                // You can do the operations on the object for which the property is set,
                // for example, for panel - set Visible
            }
        }
    }
