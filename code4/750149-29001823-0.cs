    namespace MyApplication
    {
        /// <summary>
        /// Interaction logic for App.xaml
        /// </summary>
        public partial class App : Application
        {
            static App()
            {
                // Ensure the current culture passed into bindings is the OS culture.
                // By default, WPF uses en-US as the culture, regardless of the system settings.
                //
                FrameworkElement.LanguageProperty.OverrideMetadata(
                  typeof(FrameworkElement),
                  new FrameworkPropertyMetadata(XmlLanguage.GetLanguage(CultureInfo.CurrentCulture.IetfLanguageTag)));
            }
    
            protected override void OnStartup(StartupEventArgs e)
            {
                base.OnStartup(e);
    
                var window = new MainWindow();
                
                // To ensure all the other Views of a type Window get closed properly.
                ShutdownMode = ShutdownMode.OnMainWindowClose;
    
                // Create the ViewModel which the main window binds.
                var viewModel = new MainWindowViewModel();
    
                // When the ViewModel asks to be closed,
                // close the window.
                EventHandler handler = null;
                handler = delegate
                {
                    viewModel.RequestClose -= handler;
                    window.Close();
                };
                viewModel.RequestClose += handler;
    
                // Allow all controls in the window to bind to the ViewModel by
                // setting the DataContext, which propagates down the element tree.
                window.DataContext = viewModel;
                window.Show();
            }
        }
    }
