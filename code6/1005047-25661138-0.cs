    //App
    public partial class App : Application
    {
        public string CustomerCode { get; set; }
        protected override void OnStartup(StartupEventArgs e)
        {
            this.CustomerCode=e.Args[0].ToString();
            base.OnStartup(e);
        }
    }
    //MainWindow
     public partial class MainWindow : Window
    {
        public MainWindow()
        {
            var hereIsMyCode=(Application.Current as App).CustomerCode;
            InitializeComponent();
        }
    }
