    public static class ScrollViewerProperties {
        public static readonly DependencyProperty IsScrollingWithMouseWheelProperty = DependencyProperty.RegisterAttached(
            "IsScrollingWithMouseWheel", typeof (bool), typeof (ScrollViewerProperties), new PropertyMetadata(default(bool)));
        public static void SetIsScrollingWithMouseWheel(DependencyObject element, bool value) {
            element.SetValue(IsScrollingWithMouseWheelProperty, value);
        }
        public static bool GetIsScrollingWithMouseWheel(DependencyObject element) {
            return (bool) element.GetValue(IsScrollingWithMouseWheelProperty);
        }
    }
