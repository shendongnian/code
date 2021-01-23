    namespace guiClient
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window, IDataExchangeCallback
        {
            public MainWindow()
            {
                InitializeComponent();
                Register();
            }
    
            public void Result(string result)
            {
                //this will not cause the application to hang
                Application.Current.Dispatcher.BeginInvoke(new Action(
                  () => textBox.Text = result));
            }
    
            public void Register()
            {
                InstanceContext instanceContext = new InstanceContext(this);
                DataExchangeClient client = new DataExchangeClient(instanceContext);
    
                client.RegisterClient(Guid.NewGuid().ToString());
            }
        }
    }
