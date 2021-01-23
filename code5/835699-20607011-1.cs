    namespace Pin.Visualisation
    {
        public partial class App : Application
        {
            private void OnStartup(object sender, StartupEventArgs e)
            {
                var view = new MainWindow();
                view.Show();
            }
        }
    }
