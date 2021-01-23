    public static class FocusHelper
    {
    public static void Focus(UIElement element)
    {
     element.Dispatcher.BeginInvoke(DispatcherPriority.Input, new ThreadStart(delegate()
     {
        element.Focus();
     }));
    }
    }
