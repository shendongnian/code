    public class MainWindowViewModel
    {
        // this should be called on the UI thread
        public void Start()
        {
            // get the dispatcher for the UI thread
            var uiDispatcher = Dispatcher.CurrentDispatcher;
            // start the background thread and pass it the UI thread dispatcher
            Task.Factory.StartNew(() => BackgroundThreadProc(uiDispatcher));
        }
        // this is called on the background thread
        public void BackgroundThreadProc(Dispatcher uiDispatcher)
        {
            for (var i = 0; i < 10000; i++)
            {
                // create object
                var animal = new Animal { Name = "test" + i };
                // invoke list.Add on the UI thread
                uiDispatcher.Invoke(new Action(() => list.Add(animal)));
                // sleep
                System.Threading.Thread.Sleep(1);
            }
        }
    }
