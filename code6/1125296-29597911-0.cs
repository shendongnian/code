    public partial class main_screen: UserControl
    {
        public Delegate del;
        public main_screen()
        {
            InitializeComponent();
        }
        public void method1()
        {
            del.DynamicInvoke();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            method1();
        }
    }
