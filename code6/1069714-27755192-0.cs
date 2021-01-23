    // This one defines the signature of your exit event handler
    public delegate void OnExitHandler(UserControl sender);
    // This is your child, UserControl
    public partial class MyChild : UserControl
    {
        public event OnExitHandler OnExit;
        public MyChild()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.OnExit(this);
        }
    }
    // This is your parent, Window
    public partial class MainWindow : Window
    {
        private UserControl1 _control; // You can have a List<UserControl> for multiple
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _control = new UserControl1();
            _control.OnExit += _control_OnExit; // Subscribe to event so you can remove the child when it exits
            _content.Content = _control; // _content is a ContentControl defined in Window.xaml
        }
        private void _control_OnExit(UserControl sender)
        {
            if(sender == _control)
            {
                // Or if you have a collection remove the sender like
                // _controls.Remove(sender);
                _control = null;
                _content.Content = null;
            }
        }
    }
