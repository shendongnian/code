    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var mainViewModel = new MainViewModel
            {
                ListItems = new ObservableCollection<MyModel>
                {
                    new MyModel
                    {
                        MyPropertyText = "hello",
                        ShowText = true,
                        ShowTextbox = Visibility.Visible
                    }
                }
            };
            var app = new MainWindow() {DataContext = mainViewModel};
            app.Show();
        }
    }
