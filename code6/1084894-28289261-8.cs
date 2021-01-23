    internal class MyEventListener : EventListener
    {
        protected override void OnEventSourceCreated(EventSource eventSource)
        {
            base.OnEventSourceCreated(eventSource);
            if (eventSource.Name == "System.Threading.Tasks.TplEventSource")
            {
                var enabled = eventSource.IsEnabled();
                // trying to disable - unsupported command :(
                System.Diagnostics.Tracing.EventSource.SendCommand(
                    eventSource, EventCommand.Disable, new System.Collections.Generic.Dictionary<string, string>());
            }
        }
    }
    // ...
    public sealed partial class App : Application
    {
        static MyEventListener listener = new MyEventListener();
    }
