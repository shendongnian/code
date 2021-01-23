     public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var vm = new ViewModel();
            var window = new MainWindow();
            window.DataContext = vm;
            window.Show();
        }
    }
