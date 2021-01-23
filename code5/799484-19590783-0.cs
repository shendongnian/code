      public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
            }
    
            private void Window_Loaded(object sender, RoutedEventArgs e)
            {
              var resource= Application.Current.TryFind("ApplicationResource");
            }
        }
    
        public static class ApplicationExtension
        {
            public static Object TryFind(this Application application,string resourceName)
            {
                return Application.Current.TryFindResource(resourceName) ?? "Your fall back resource";
            }
        }
 
