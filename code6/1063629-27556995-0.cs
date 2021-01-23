    namespace YourProject.PropertiesExtension
    {
        public static class WindowExt
        {
            public static readonly DependencyProperty WindowStartupLocationProperty;
    
            public static void SetWindowStartupLocation(DependencyObject DepObject, WindowStartupLocation value)
            {
                DepObject.SetValue(WindowStartupLocationProperty, value);
            }
    
            public static WindowStartupLocation GetWindowStartupLocation(DependencyObject DepObject)
            {
                return (WindowStartupLocation)DepObject.GetValue(WindowStartupLocationProperty);
            }
    
            static WindowExt() 
            {            
                WindowStartupLocationProperty = DependencyProperty.RegisterAttached("WindowStartupLocation",
                                                          typeof(WindowStartupLocation),
                                                          typeof(WindowExt),
                                                          new UIPropertyMetadata(WindowStartupLocation.Manual, OnWindowStartupLocationChanged));
            }
    
            private static void OnWindowStartupLocationChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
            {
                Window window = sender as Window; 
    
                if (window != null) 
                {
                    window.WindowStartupLocation = GetWindowStartupLocation(window);
                }
            }
        }
    }
