    public partial class App : Application
    {
        public App()
        {
            EventManager.RegisterClassHandler(
                typeof (UIElement),             
                UIElement.GotKeyboardFocusEvent,
                new RoutedEventHandler(GotKeyboardFocusEventHandler));
            EventManager.RegisterClassHandler(
                typeof (UIElement), 
                UIElement.LostKeyboardFocusEvent,
                new RoutedEventHandler(LostKeyboardFocusEventHandler));
        }
        private void GotKeyboardFocusEventHandler(object sender, RoutedEventArgs routedEventArgs)
        {
           ...
        }
        private void LostKeyboardFocusEventHandler(object sender, RoutedEventArgs routedEventArgs)
        {
           ...
        }
    }
