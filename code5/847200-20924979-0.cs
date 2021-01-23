    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        readonly string Token;
        public MainWindow()
        {
            Token = Guid.NewGuid().ToString();
            InitializeComponent();
            DataContext = new MainViewModel(Token);
        }
    }
