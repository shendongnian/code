    namespace WpfApplication1
    {
    public partial class Page1 : Page
    {
        public delegate void SendName(string Name);
        public static event SendName onNameSend;
        public Page1()
        {
            InitializeComponent();
        }
        private void SendButton(object sender, RoutedEventArgs e)
        {
            onNameSend("Name to Send");
        }
    }
    }
