    public partial class MainWindow : Window
    {
        System.Threading.Timer timer;
        public MainWindow()
        {
            InitializeComponent();
            timer = new System.Threading.Timer(OnCallBack, null, 0, 30 * 1000);
        }
        private void OnCallBack(object state)
        {
            //code to check report 
            Dispatcher.Invoke(() =>
            {
                //code to update ui
                this.Label.Content = string.Format("Fired at {0}", DateTime.Now);
            });
        }
    }
