    public partial class MainWindow : Window
    {
        public Model Model
        {
            get;
            set;
        }
    
        public MainWindow()
        {
            Model=new Model();
    
            InitializeComponent();
    		
    		this.DataContext = this;
        }
    } 
