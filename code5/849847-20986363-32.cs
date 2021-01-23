    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            ViewModel = new NestedItemsViewModel();
            InitializeComponent();
        }
        public NestedItemsViewModel ViewModel { get; set; }
        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            ViewModel.SelectChoice(3, 3);
        }
    }
