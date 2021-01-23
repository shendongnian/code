    public class LumelauaPikkused
    {
        private ObservableCollection<string> _lumelauaPikkused;
        private System.Windows.Threading.DispatcherTimer _dispatcherTimer;
        public LumelauaPikkused()
        {
            this._lumelauaPikkused = new ObservableCollection<string>();
            this._lumelauaPikkused.Add("One");
            this._lumelauaPikkused.Add("Two");
            this._lumelauaPikkused.Add("Three");
            _dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            _dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            _dispatcherTimer.Interval = new TimeSpan(0, 0, 20);
            _dispatcherTimer.Start();
        }
        void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            this._lumelauaPikkused.Add("Four");
            this._lumelauaPikkused.Add("Five");
            this._lumelauaPikkused.Add("Six");
            _dispatcherTimer.Stop();
        }
        public ObservableCollection<string> Lumelauapikkused
        {
            get { return _lumelauaPikkused; }
            set { _lumelauaPikkused = value; }
        }
    }
