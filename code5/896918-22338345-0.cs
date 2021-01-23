    public static class FocusBehavior
    {
        #region Constants
        public static readonly DependencyProperty IsFocusedProperty =
            DependencyProperty.RegisterAttached("IsFocused", typeof (bool?),
                typeof (FocusBehavior), new FrameworkPropertyMetadata(IsFocusedChanged));
        #endregion
        #region Public Methods
        public static bool GetIsFocused(DependencyObject obj)
        {
            return (bool) obj.GetValue(IsFocusedProperty);
        }
        public static void SetIsFocused(DependencyObject obj, bool value)
        {
            obj.SetValue(IsFocusedProperty, value);
        }
        #endregion
        #region Event Handlers
        private static void IsFocusedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var uie = (UIElement) d;
            if ((bool) e.NewValue)
                uie.Dispatcher.BeginInvoke(DispatcherPriority.Input, new ThreadStart(() => Keyboard.Focus(uie)));
        }
        #endregion Event Handlers
    }
