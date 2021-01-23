    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // Set the View's DataContext to our ViewModel
            var vm = new ViewModel();
            this.DataContext = new ViewModel();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Populate Category Collection with dummy data.
            var vm = ((ViewModel)this.DataContext);
            vm.CategoryLinkCollection = new ObservableCollection<Category>()
            {
                new Category("Cat 1"),
                new Category("Cat 2"),
                new Category("Cat 3"),
                new Category("Cat 4"),
                new Category("Cat 5"),
                new Category("Cat 6"),
            };
            vm.SelectedCategory = vm.CategoryLinkCollection[0];
        }
        private void btn_Click(object sender, RoutedEventArgs e)
        {
            var vm = ((ViewModel)this.DataContext);
            vm.SelectedCategory = vm.CategoryLinkCollection[3];
        }
    }
