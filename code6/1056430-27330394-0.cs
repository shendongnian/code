    public partial class MyPage : Page 
    {
        public MyPage()
        {
            InitializeComponent();
            this.Loaded += page_Loaded;
        }
        private void page_Loaded(object sender, RoutedEventArgs e)
        {
            myChBox.Checked += myChBox_Checked;
        }
        private void myChBox_Checked(object sender, RoutedEventArgs e) 
        {
            if (myComboBox != null)
            {
               myComboBox ... // Should not be null, but check anyway
            }
        }
}
