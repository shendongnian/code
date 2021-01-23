    public partial class MainWindow : Window
    {
        MainViewModel _vm;
    	
        public MainWindow()
        {
            InitializeComponent();
    		
    		_vm = new MainViewModel();
    		this.DataContext = _vm;
        }
    } 
