    public partial class App
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            new MainWindow {DataContext = new MyAppViewModel()}.Show();
        }
    }
