        /// <summary>
        /// Interaction logic for App.xaml
        /// </summary>
        public partial class App : Application
        {
            // Add this override function
            protected override void OnStartup(StartupEventArgs e)
            {
                this.StartupUri = new Uri("View/MainWindow.xaml", UriKind.RelativeOrAbsolute);
                //this.StartupUri = new Uri("View/MainWindowServer.xaml", UriKind.RelativeOrAbsolute);
            }
        }
