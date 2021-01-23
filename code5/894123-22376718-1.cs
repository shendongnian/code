    public partial class App : Application
    {
        public App()
        {
            this.Startup += App_Startup;
        }
        public void App_Startup(object sender, StartupEventArgs e)
        {
            
            this.MainWindow = new MainWindow();
            
            //create view model and set data context
            MainWindowViewModel vm = new MainWindowViewModel();
            this.MainWindow.DataContext = vm;
            //show window
            this.MainWindow.ShowDialog(vm);
        }
    }
