    public static class CWaitingMessage
    {
        private static event Action CloseWindow = delegate { };
        public static void Open(string sMessage)
        {
            Thread t = new Thread(delegate()
                   {
                       frmWaiting window = new frmWaiting(sMessage);
                       CloseWindow += () => window.Dispatcher.BeginInvoke(new ThreadStart(() => window.Close()));
                       window.Closed += (sender2, e2) => Window.Dispatcher.InvokeShutdown();
                       window.Show();
                       System.Windows.Threading.Dispatcher.Run();
                   });
            t.SetApartmentState(ApartmentState.STA);
            t.Start();
        }   
        public static void Close()
        {
            CloseWindow();
        }      
    }
