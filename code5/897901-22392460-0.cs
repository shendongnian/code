    // In your PCL
    public abstract class PortableDispatcher
    {
        public abstract void Invoke(Action action);
    }
    
    // In your app
    public class WinRTDispatcher : PortableDispatcher
    {
        public override void Invoke(Action action)
        {
            Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.
                RunAsync(CoreDispatcherPriority.Normal, new DispatchedHandler(action);
        }
    }
