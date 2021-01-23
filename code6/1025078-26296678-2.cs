    public partial class Page1 : Page
    {
        public Page1()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Page2 p = new Page2(2);
            this.NavigationService.Navigate(p);
        }
    }
