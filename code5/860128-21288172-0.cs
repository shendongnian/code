    public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
              
    
                string[] files = new string[]{};
                ObservableCollection<string> observableCollection = new ObservableCollection<string>(files);
                comboBox1.ItemsSource = observableCollection; 
    
            }
    
            
            
    
        }
