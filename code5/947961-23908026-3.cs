    public partial class App : Application {
        protected override void OnStartup(StartupEventArgs e) {
            var model = new AppModel(new Repository());
            var viewModel = new MainWindowViewModel(model);
            var view = new MainWindow() {DataContext = viewModel};
            view.Show();
        }
    }
