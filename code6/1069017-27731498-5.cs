     public partial class MainWindow : Window
    {
        public MyModel MyModel { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            //MyModel = new MyModel { MyCounter = new Counter() };
            //this.DataContext = MyModel;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var myModel = this.Resources["myModal"] as MyModel;
            if (myModel != null)
            {
                myModel.MyCounter.incrementCounter();
            }
        }
    }
