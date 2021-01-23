    public partial class App : Application
    {
        private DummyListener dl;
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            Current.ShutdownMode = ShutdownMode.OnMainWindowClose;
            dl = new DummyListener();
            PresentationTraceSources.DataBindingSource.Listeners.Add(dl);
            var d = new MainWindow();
            d.DataContext = d;
            MainWindow = d;
            d.Show();
        }
    }
