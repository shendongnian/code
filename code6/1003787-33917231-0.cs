    public static class FlyoutHelper
    {
        public static readonly DependencyProperty IsHiddenProperty =
            DependencyProperty.RegisterAttached("IsHidden", typeof(bool), typeof(FlyoutHelper), new PropertyMetadata(false, OnIsHiddenPropertyChanged));
        public static void SetIsHidden(DependencyObject d, bool value)
        {
            d.SetValue(IsHiddenProperty, value);
        }
        public static bool GetIsHidden(DependencyObject d)
        {
            return (bool)d.GetValue(IsHiddenProperty);
        }
        private static void OnIsHiddenPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var flyout = d as FlyoutBase;
            bool isHidden = (bool)e.NewValue;
            if (flyout != null && isHidden)
            {
                flyout.Hide();
            }
        }
    }
