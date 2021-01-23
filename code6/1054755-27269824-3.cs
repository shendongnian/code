    private void Application_Startup(object sender, StartupEventArgs e)
            {
                vm = new ViewModel();
                mw = new MainWindow();
                mw.DataContext = vm;
                mw.Show();
            }
