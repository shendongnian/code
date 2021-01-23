        public partial class App : Application
        {
            protected override void OnStartup(StartupEventArgs e)
            {
                DispatcherUnhandledException += App_DispatcherUnhandledException;
            }
            void App_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
            {
                LogError(e);
    // MessageBox.Show(e.Exception.Message);
                e.Handled = true;
            }
