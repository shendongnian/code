    public partial class MainWindow : Window
    {
        MyTestObject myTestObject;
        public MyTestObject MyTestObjectProperty { get { return myTestObject; } }
        public MainWindow()
        {
            myTestObject = new MyTestObject ();
            this.DataContext = this;
            InitializeComponent();
        }
    }
