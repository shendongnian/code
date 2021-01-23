    public static class WindowHelper
    {
        public static void CreateWindow<TWindow>(Action onClose = null)
            where TWindow : Window, new()
        {
            // Create a thread
            Thread newWindowThread = new Thread(new ThreadStart(() =>
            {
                SynchronizationContext.SetSynchronizationContext(
                    new DispatcherSynchronizationContext(
                        Dispatcher.CurrentDispatcher));
                TWindow tempWindow = new TWindow();
                tempWindow.Closed += (s, e) => 
                   { 
                      if(onClose != null)
                          onClose();
                      Dispatcher.CurrentDispatcher.BeginInvokeShutdown(DispatcherPriority.Backgroud);
                   }; 
                tempWindow.Show();
                System.Windows.Threading.Dispatcher.Run();
            }));
            newWindowThread.SetApartmentState(ApartmentState.STA);
            newWindowThread.IsBackground = true;
            newWindowThread.Start();
        }
    }
