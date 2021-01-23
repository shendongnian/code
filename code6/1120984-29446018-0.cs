      public static class WindowLog
    {
        public static readonly DependencyProperty EnableLogProperty =
            DependencyProperty.RegisterAttached(
                "EnableLog",
                typeof(bool),
                typeof(WindowLog),
                new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.None, OnEnableWindowLogChanged));
        public static void SetEnableWindowLog(Window window, bool value)
        {
            window.SetValue(EnableLogProperty, value);
        }
        public static bool GetEnableWindowLog(Window element)
        {
            return (bool)element.GetValue(EnableLogProperty);
        }
        private static void OnEnableWindowLogChanged(
            DependencyObject dependencyObject,
            DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
        {
            Window window = dependencyObject as Window;
            if (window == null)
            {
                return;
            }
            if (GetEnableWindowLog(window))
            {
                Register(window);
            }
            else
            {
                Unregister(window);
            }  
        }
        private static void Unregister(Window window)
        {
            window.Closing -= Window_Closing;
            window.Activated -= Window_Activated;
            window.Closed -= Window_Closed;
        }
        private static void Register(Window window)
        {
            window.Closing += Window_Closing;
            window.Activated += Window_Activated;
            window.Closed += Window_Closed;
        }
        private static void Window_Closed(object sender, EventArgs e)
        {
            Window window = (Window)sender;     
            window.Closing -= Window_Closing;
            window.Activated -= Window_Activated;
            window.Closed -= Window_Closed;
        }
        private static void Window_Activated(object sender, EventArgs e)
        {  
            // do something
        }
        private static void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // do something
        } 
    }
