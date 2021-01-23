    public partial class App : Application
    {
        public App()
        {
            ...
            this.UnhandledException += this.Application_UnhandledException;
            InitializeComponent();
        }
        private void Application_UnhandledException(object sender, 
            ApplicationUnhandledExceptionEventArgs e)
        {
            Debug.WriteLine(e.ExceptionObject);
        }
    }
