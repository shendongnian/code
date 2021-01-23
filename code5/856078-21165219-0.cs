    <param name="initParams" value="key1=10" />
    private void Application_Startup(object sender, StartupEventArgs e)
    {
        foreach (var item in e.InitParams)
        {
            this.Resources.Add(item.Key, item.Value);
        }
    
        this.RootVisual = new MainPage();
    }
    public partial class MainPage : UserControl
    {
        string module = string.Empty;
        int key1 = 0;
    
        public MainPage()
        {
            InitializeComponent();
    
            this.Loaded += new RoutedEventHandler(MainPage_Loaded);
        }
    
        void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
           
            if (App.Current.Resources.Contains("key1"))
            {
                int.TryParse(App.Current.Resources["key1"].ToString(), out key1);
            }
      
        }
    }
