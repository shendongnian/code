    public partial class Window2 : Window
    {
        public delegate void MyDelegate(object value);
        public event MyDelegate MyCustomEvent;
        public Window2()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MyCustomEvent(100);
        }
    }
