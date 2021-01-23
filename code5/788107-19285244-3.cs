        /// <summary>
        /// Interaction logic for App.xaml
        /// </summary>
        public partial class App : Application
        {
            // Add this override function
            protected override void OnStartup(StartupEventArgs e)
            {
                if(e.Args.Contains("Client"))
                    this.StartupUri = new Uri("View/MainWindow.xaml", UriKind.RelativeOrAbsolute);
                else
                    this.StartupUri = new Uri("View/MainWindowServer.xaml", UriKind.RelativeOrAbsolute);
            }
        }
