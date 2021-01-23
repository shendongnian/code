    public partial class SomePage : UserControl
    {
        public SomePage()
        {
            InitializeComponent();
            this.DataContext = new SomePageViewModel();
        }
        private void pageRoot_Loaded(object sender, RoutedEventArgs e)
        {
            ((SomePageViewModel)this.DataContext).AddLevels(AddLevel);
        }
    }
