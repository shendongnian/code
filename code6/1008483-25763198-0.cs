        public static readonly DependencyProperty DynamicNameProperty = DependencyProperty.RegisterAttached(
            "DynamicName", typeof(object), typeof(FrameworkElement), new PropertyMetadata(default(object), PropertyChangedCallback));
        private static void PropertyChangedCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs eventArgs)
        {
            FrameworkElement frameworkElement = (FrameworkElement)dependencyObject;
            if (eventArgs.NewValue != null)
            {
                frameworkElement.Name = eventArgs.NewValue.ToString();
            }
        }
