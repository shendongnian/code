    public partial class MainWindow : Window
    {
        public MainWindow()
        {
         ConfigurationFilter.DataContext = this;
        }
    
        public MyModel Filters { get; set; }
    }
