    //IN MainWindow
    private void button1_Click(object sender, RoutedEventArgs e)
    {
        DllstringTest st = new DllstringTest();
        st.testString = "5";
        Window1 w1 = new Window1();
        w1.DllInstance = st;
        w1.Show();
    }
    
    //IN Window1
    public partial class Window1 : Window
    {
        public DllstringTest DllInstance { get;set; }
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(DllInstance.testString);
        }
    }
