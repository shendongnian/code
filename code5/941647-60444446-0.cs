        public partial class MainWindow : Window
        {
           Employee employee = new Employee();
    
           public MainWindow()
           {
               InitializeComponent();
    
               DataContext = employee;
           }
        }
