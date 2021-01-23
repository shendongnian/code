       public partial class MainWindow : Window
        {
     
            public MainVM ViewModel { get; set; }
     
            public MainWindow()
            {
                InitializeComponent();
     
                // Set the windows data context so all controls can have it.
                DataContext = ViewModel = new MainVM();
     
            }
     
        }
