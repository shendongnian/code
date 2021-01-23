    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            ViewModel = new MyViewModel2();
            InitializeComponent();
        }
        public MyViewModel2 ViewModel { get; set; }
    }
