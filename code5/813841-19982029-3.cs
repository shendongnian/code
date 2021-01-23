    public partial class MainWindow : Window
    {
        MyTestObject myTestObject;
        public MainWindow()
        {
            myTestObject = new MyTestObject ();
            this.DataContext = myTestObject;
            InitializeComponent();
        }
    }
