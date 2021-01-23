    public static class KeyBindingBehavior
    {
        //to keep window's bindings.
        private static InputBindingCollection windowBindings;
        public static bool GetLimitKeyBindings(DependencyObject obj)
        {
            return (bool)obj.GetValue(LimitKeyBindingsProperty);
        }
        public static void SetLimitKeyBindings(DependencyObject obj, bool value)
        {
            obj.SetValue(LimitKeyBindingsProperty, value);
        }
        public static readonly DependencyProperty LimitKeyBindingsProperty =
            DependencyProperty.RegisterAttached(
            "LimitKeyBindings",
            typeof(bool),
            typeof(KeyBindingBehavior),
            new PropertyMetadata(false, PropertyChangedCallback));
        private static void PropertyChangedCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs args)
        {
            TextBox textBox = dependencyObject as TextBox;
            if (textBox != null)
            {
                textBox.GotKeyboardFocus += textBox_GotKeyboardFocus;
                textBox.LostKeyboardFocus += textBox_LostKeyboardFocus;
            }
        }
        static void textBox_LostKeyboardFocus(object sender, System.Windows.Input.KeyboardFocusChangedEventArgs e)
        {
            var window = GetParentWindow(sender as DependencyObject);
            window.InputBindings.AddRange(windowBindings);
        }
        static void textBox_GotKeyboardFocus(object sender, System.Windows.Input.KeyboardFocusChangedEventArgs e)
        {
            var window = GetParentWindow(sender as DependencyObject);
            windowBindings = new InputBindingCollection(window.InputBindings);
            window.InputBindings.Clear();
        }
        // This helper method should be in seperate class
        public static Window GetParentWindow(DependencyObject child)
        {
            DependencyObject parentObject = VisualTreeHelper.GetParent(child);
            if (parentObject == null)
            {
                return null;
            }
            Window parent = parentObject as Window;
            if (parent != null)
            {
                return parent;
            }
            else
            {
                return GetParentWindow(parentObject);
            }
        }
    }
