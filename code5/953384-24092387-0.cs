    class OpenFileDialogOnClickBehavior
    {
        public static bool GetOpenFileDialogOnClick(Button button)
        {
            return (bool)button.GetValue(OpenFileDialogOnClickProperty);
        }
        public static void SetOpenFileDialogOnClick(Button button, bool value)
        {
            button.SetValue(OpenFileDialogOnClickProperty, value);
        }
        public static readonly DependencyProperty OpenFileDialogOnClickProperty =
            DependencyProperty.RegisterAttached(
            "OpenFileDialogOnClick",
            typeof(bool),
            typeof(OpenFileDialogOnClickBehavior),
            new UIPropertyMetadata(false, OnOpenFileDialogOnClick));
        static void OnOpenFileDialogOnClick(DependencyObject depObj, DependencyPropertyChangedEventArgs e)
        {
            Button button = depObj as Button;
            if (button == null)
                return;
            if (e.NewValue is bool == false)
                return;
            if ((bool)e.NewValue)
                button.Click += OnClick;
            else
                button.Click -= OnClick;
        }
        static void OnClick(object sender, RoutedEventArgs e)
        {
            // Only react to the Click event raised by the Button. Ignore all ancestors
            // who are merely reporting that a descendant's Click fired.
            if (!ReferenceEquals(sender, e.OriginalSource))
                return;
            Button button = e.OriginalSource as Button;
            if (button != null)
            {
                // Open File Dialog or any action to react to the Click Event.
            }
        }
    }
