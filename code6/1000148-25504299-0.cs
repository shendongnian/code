    public class DispatcherBuilder : IBuilder<Dispatcher>
    {
        public Dispatcher Build()
        {
            Dispatcher dispatcher = null;
            var manualResetEvent = new ManualResetEvent(false);
            var thread = new Thread(() =>
                {
                    dispatcher = Dispatcher.CurrentDispatcher;
                    var synchronizationContext = new DispatcherSynchronizationContext(dispatcher);
                    SynchronizationContext.SetSynchronizationContext(synchronizationContext);
                    manualResetEvent.Set();
                    Dispatcher.Run();
                });
            thread.Start();
            manualResetEvent.WaitOne();
            manualResetEvent.Dispose();
            return dispatcher;
        }
    }
