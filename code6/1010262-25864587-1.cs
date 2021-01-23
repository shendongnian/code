        public static readonly DependencyProperty FrameworkElementProperty =
                DependencyProperty.RegisterAttached("FrameworkElement",
                typeof(FrameworkElement),
                typeof(PopupKeyboard),
                new FrameworkPropertyMetadata(default(FrameworkElement),
                    new PropertyChangedCallback(PopupKeyboard.OnFrameworkElementChanged)));
    
            [AttachedPropertyBrowsableForType(typeof(FrameworkElement))]
            public static FrameworkElement GetFrameworkElement(DependencyObject element)
            {
                if (element == null)
                    throw new ArgumentNullException("element");
    
                return (FrameworkElement)element.GetValue(FrameworkElementProperty);
            }
    
            public static void SetFrameworkElement(DependencyObject element, bool value)
            {
                if (element == null)
                    throw new ArgumentNullException("element");
    
                element.SetValue(FrameworkElementProperty, value);
            }
    
    private static void OnFrameworkElementChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
            {
                FrameworkElement fe = d as FrameworkElement;
                if (fe != null)
                {
                    // detach here
                    keyboard.FrameworkElement = fe;
                }
            }
