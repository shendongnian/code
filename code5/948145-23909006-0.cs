     public partial class App : Application
    {
        private MainWindow _mainwindow;
        public MainWindow mainwindow
        {
            get { return _mainwindow??(_mainwindow=new MainWindow()); }
            set { _mainwindow = value; }
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            _mainwindow.Show();
        }
        protected override void OnExit(ExitEventArgs e)
        {
            _mainwindow.DoSomething();
        }
    }
