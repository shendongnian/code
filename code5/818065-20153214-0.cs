    public class AppContext : ApplicationContext
    {
        private SynchronizationContext _uiThreadContext;
        ...
        public AppContext()
        {
            //Initialize context menu & tray icon
            
            _uiThreadContext = new WindowsFormsSynchronizationContext();
            _regWatcher = new ManagementEventWatcher(query);
            _regWatcher.EventArrived += new EventArrivedEventHandler(_regWatcher_EventArrived);
            _regWatcher.Start();
            ...
        }
        private void _regWatcher_EventArrived(object sender, EventArrivedEventArgs e)
        {
            ...
            _uiThreadContext.Post(new SendOrPostCallback(MyEventHandler), parameters) 
        }
