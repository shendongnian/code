    namespace UserControlPassReference
    {
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
                UserControl1 uc1 = new UserControl1(this);
            }
        }
    }
    
    namespace UserControlPassReference
    {
        public partial class UserControl1 : UserControl
        {
            private Window main;
            public UserControl1()
            {
                InitializeComponent();
            }
            public UserControl1(Window Main)
            {
                InitializeComponent();
                main = Main;
            }
        }
    }
