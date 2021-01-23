    namespace stringTest_app
    {
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        private DllstringTest st;
        public Window1(DllstringTest st)
        {
            this.st = st;
            InitializeComponent();
        }
    
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            //DllstringTest st1 = new DllstringTest();
            MessageBox.Show(this.st.testString);
    
        }
    }
}
