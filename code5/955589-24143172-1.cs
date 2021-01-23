      public partial class App : Application
        {
            protected override void OnStartup(StartupEventArgs e)
            {
                base.OnStartup(e);
                MainWindow mw = new MainWindow();
                mw.Loaded += mw_Loaded;
                mw.Show();
            }
            void mw_Loaded(object sender, RoutedEventArgs e)
            {   // loaded event comes here
                throw new NotImplementedException();
            }
        }
