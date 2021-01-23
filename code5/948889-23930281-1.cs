    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window2 wnd = new Window2();
            wnd.MyCustomEvent += wnd_MyCustomEvent;
            wnd.Show();
        }
        void wnd_MyCustomEvent(object value)
        {
            MessageBox.Show(value.ToString());
        }
    }
