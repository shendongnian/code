            public static readonly DependencyProperty VisualStatePropertyProperty =
            DependencyProperty.RegisterAttached(
            "VisualStateProperty",
            typeof(string),
            typeof(StateManager),
            new PropertyMetadata((dependencyObject, args) =>
            {
                var frameworkElement = dependencyObject as FrameworkElement;
                if (frameworkElement == null)
                    return;
                if (args.NewValue == frameworkElement.Tag.ToString())
                {
                    VisualStateManager.GoToState(frameworkElement, (string)args.NewValue, true);
                }
                else
                {
                    VisualStateManager.GoToState(frameworkElement, "Normal", true);
                }
                
            }));
