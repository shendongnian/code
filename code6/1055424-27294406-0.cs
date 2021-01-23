    public partial class MyWindow
    {
        public MyWindow()
        {
            InitializeComponent();
            DataContext = ViewModel = new MyViewModelType();
        }
    }
