    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var vm = new ViewModel();
            vm.AddSomeCommands();
            this.DataContext = vm;
        }
    }
