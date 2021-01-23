    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainWindowViewModel() {Data = new Student{Id = 1, Name = "Student"}};
        }
        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            var vm = this.DataContext as MainWindowViewModel;
            vm.Data = new Parent() {Name = "This is parent"};
        }
    }
