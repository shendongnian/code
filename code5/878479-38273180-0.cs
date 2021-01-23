    public partial class App : Application
    {
        App()
        {
            InitializeComponent();
        }
        [STAThread]
        static void Main()
        {
            SingleInstanceManager manager = new SingleInstanceManager();
            manager.Run(new[] {"teste"});
        }
    }
    public class SingleInstanceManager : WindowsFormsApplicationBase
    {
        SingleInstanceApplication app;
        public SingleInstanceManager()
        {
            this.IsSingleInstance = true;
        }
        protected override bool OnStartup(Microsoft.VisualBasic.ApplicationServices.StartupEventArgs e)
        {
            // First time app is launched
            app = new SingleInstanceApplication();
            app.Run();
            return false;
        }
        protected override void OnStartupNextInstance(StartupNextInstanceEventArgs eventArgs)
        {
            // Subsequent launches
            base.OnStartupNextInstance(eventArgs);
            app.Activate();
        }
    }
    public class SingleInstanceApplication : Application
    {
        protected override void OnStartup(System.Windows.StartupEventArgs e)
        {
            base.OnStartup(e);
            // Create and show the application's main window
            MainWindow window = new MainWindow();
            window.Show();
        }
        public void Activate()
        {
            // Reactivate application's main window
            this.MainWindow.WindowState = WindowState.Normal;
            this.MainWindow.Activate();
        }
    }
