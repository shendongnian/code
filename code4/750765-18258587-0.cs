    public partial class StartupSplash : Window
    {
        private Thread _showHideThread;
        public StartupSplash()
        {
            InitializeComponent();
            this.Closing += OnCloseDialog;
        }
        public string Message
        {
            get
            {
                return this.lb_progress.Content.ToString();
            }
            set
            {
                if (Application.Current.Dispatcher.Thread == System.Threading.Thread.CurrentThread)
                    this.lb_progress.Content = value;
                else
                    this.lb_progress.Dispatcher.Invoke(new Action(() => this.lb_progress.Content = value));
            }
        }
        public void ShowMe()
        {
            _showHideThread = new Thread(new ParameterizedThreadStart(doShowHideDialog));
            _showHideThread.Start(true);
        }
        public void HideMe()
        {
            //_showHideThread.Start(false);
            this.doShowHideDialog(false);
        }
        private void doShowHideDialog(object param)
        {
            bool show = (bool)param;
            if (show)
            {
                if (Application.Current.Dispatcher.Thread == System.Threading.Thread.CurrentThread)
                    this.ShowDialog();
                else
                    Application.Current.Dispatcher.Invoke(new Action(() => this.ShowDialog()));
            }
            else
            {
                if (Application.Current.Dispatcher.Thread == System.Threading.Thread.CurrentThread)
                    this.Close();
                else
                    Application.Current.Dispatcher.Invoke(new Action(() => this.Close()));
            }
        }
        private void OnCloseDialog(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }
    }
