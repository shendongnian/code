    public class LoadWpfAppDll
    {
        private readonly ManualResetEvent _evtMainWindowInstantiated = new ManualResetEvent(false);
        private MainWindow mainWindow = null;
        public void Load(string[] args)
        {
            try
            {
                ......all the stuff you do in Load()...
                try
                {
                    mainWindow = new MainWindow();
                    mainWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                    splashWindow.Close();
                    application.Startup +=
                        (sender, e) => _evtMainWindowInstantiated.Set();
                    application.Run();
                }
                catch (Exception ex)
                {
                    splashWindow.Close();
                    MessageBox.Show("Error starting application:" + Environment.NewLine + ex.ToString(), "Error Message", MessageBoxButton.OK, MessageBoxImage.Error);
                    mainWindow = null;
                }
            }
            finally
            {
                //
                // Ensures that the _evtMainWindowInstantiated is always set, even in
                // failure case. If this would not be done, a failure of the Load
                // method could block other threads waiting on this ManualResetEvent
                // in one of the public methods below.
                //
                _evtMainWindowInstantiated.Set();
            }
        }
        private void InvokeOnMainWindowThread(Action action)
        {
            _evtMainWindowInstantiated.WaitOne();
            if (mainWindow == null)
            {
                ...something bad happened in Load()...
                ...do error handling or just return, whatever is appropriate...
            }
            //
            // Make sure that the action is invoked on the mainWindow thread.
            // If InvokeOnMainWindowThread is already called on the
            // mainWindow thread, the action should not be queued by the
            // dispatcher but should be executed immediately.
            //
            if (mainWindow.Dispatcher.CheckAccess()) action();
            else mainWindow.Dispatcher.Invoke(action, null);
        }
        
        public void ShowWPFAppDLL()
        {
            InvokeOnMainWindowThread(mainWindow.Show);
        }
    }
