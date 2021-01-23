    public partial class App : Application
    {
        #region Instance Variables
        private Thread newWindowThread;
    
        #endregion
    
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            newWindowThread = new Thread(new Thread(() =>
            {
                // Create and show the Window
                Config tempWindow = new Config();
                tempWindow.Show();
                // Start the Dispatcher Processing
                System.Windows.Threading.Dispatcher.Run();
            }));
            // Set the apartment state
            newWindowThread.SetApartmentState(ApartmentState.STA);
            // Make the thread a background thread
            newWindowThread.IsBackground = true;
        }
    
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            // Start the thread
            newWindowThread.Start();
        }
    }
