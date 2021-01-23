    public partial class TestControl : UserControl
    {
        public static readonly DependencyProperty ImageProperty = DependencyProperty.Register("TabItemImage" , typeof(string) , typeof(TabItem) , null);
        public static readonly DependencyProperty TextProperty = DependencyProperty.Register("TabItemText" , typeof(string) , typeof(TabItem) , null);
        public string TabItemImage
        {
            get { return (string)GetValue(ImageProperty); }
            set { SetValue(ImageProperty , value); }
        }
        public string TabItemText
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty , value); }
        }
        public TestControl()
        {
            InitializeComponent();
            this.DataContext = this;
        }
        // or
        private void TestControl_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            // Add logic...
        }
        // or
        private void TestControl_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // Add logic...
        }
        // or
        private void TestControl_OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            // Add logic...
        }
    }
