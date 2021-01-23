    public partial class MainWindow : Window
    {
        public delegate void ValuePassDelegate();
        public event ValuePassDelegate ValuePassEvent;
    
        public MainWindow()
        {
            InitializeComponent();
            ValuePassEvent += new ValuePassDelegate(method1);
            main_screen_obj.del = ValuePassEvent;
        }
        public void method1()
        {
            contentMain.Content = new ClubRules();
        }
    }
