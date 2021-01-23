    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            var vm = new MyViewModel(new NavigationService());
            this.DataContext = vm;
        }
    }
