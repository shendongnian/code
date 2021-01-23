    public partial class MyWindow
    {    
        public static System.Windows.Window windowRef;
    
        public MyWindow()
        {
            InitializeComponent();
            Initialize();
        }
    
        private void Initialize()
        {
            windowRef = this;
        }
        private static void Transiever(object sender, ReceivedEventArgs e)
        {
            FunkTasterServiceClient client = new FunkTasterServiceClient();
            client.Endpoint.Address = 
                new EndpointAddress(new Uri((windowRef.serviceURL.Text),
            client.Endpoint.Address.Identity, client.Endpoint.Address.Headers);
            client.GetReceivedTelegram(e.Telegram.ToString());
        }    
    }
