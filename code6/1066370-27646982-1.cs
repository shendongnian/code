    private static readonly Mutex Mutex = new Mutex(true, "put your unique value here or GUID");
        private static MainWindow _mainWindow;       
        [STAThread]
        static void Main()
        {
            if (Mutex.WaitOne(TimeSpan.Zero, true))
            {
                var app = new App();
                _mainWindow = new MainWindow();
                app.Run(_mainWindow);
                Mutex.ReleaseMutex();
            }
            else
            {
                //MessageBox.Show("You can only run one instance!");
                _mainWindow.WindowState = WindowState.Maximized;
            }
        }
