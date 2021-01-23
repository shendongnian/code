    public class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            Init();
        }
    
        public async void Init(){
    
            _webService = new OAuthBasedWebService();
           
            Uri uri=await _webService.Connect();
             _webService_ShowAuthorizationPage(uri);
        }
    }
    
    
    public class OAuthBasedWebService()
    {
        private OAuthWrapper _wrapper;
    
        public async Task<Uri> Connect()
        {
            return await _wrapper.GetAuthorizationUri();
           
        }
    }
