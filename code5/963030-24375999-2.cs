    public partial class MyWindow : Window
    {
        public MyWindow()
        {
            InitializeComponent();
            DataContext = new MyViewModel();
        }
    }
