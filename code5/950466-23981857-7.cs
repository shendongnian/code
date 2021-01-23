    private YourViewModel _ViewModel;
    public App()
    {
       _ViewModel = new YourViewModel();
    }
    protected override void OnStartup(StartupEventArgs e)
    {
            base.OnStartup(e);
            _MainWindow = new MainWindow();
            _MainWindow.DataContext = _ViewModel;
            _MainWindow.Show();
            //delete the startupuri row from App.xaml
    }
