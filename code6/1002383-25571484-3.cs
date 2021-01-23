    public partial class MainWindow : Window
    {
        public MyObject MyObject { get; private set; }
    
        public MainWindow()
        {
            InitializeComponent();
    
            MyObject = new MyObject();
    
            this.DataContext = MyObject;
        }
    
        private void DoSomething()
        {
            MyObject.DoSomething();
        }
    }
