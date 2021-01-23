    public partial class MainWindow : MetroWindow
    {
        public MainWindow(ChatViewModel chatViewModel)
        {
            this.DataContext = chatViewModel;
            InitializeComponent();
        }
    }
