        public event PropertyChangedEventHandler PropertyChanged;
        public MainWindowViewModel() {
            _Timer = new DispatcherTimer();
            _Timer.Interval = TimeSpan.FromSeconds(1);
            _Timer.Tick += new EventHandler(_Timer_Tick);
            _SecondsLeft = 3;
            _Timer.Start();
        }
        void _Timer_Tick(object sender, EventArgs e) {
            SecondsLeft = SecondsLeft - 1;
            if (_SecondsLeft <= 0) {
                StartFlashing = true;
                _Timer.Stop();
            }
        }
        private int _SecondsLeft;
        public int SecondsLeft {
            get { return _SecondsLeft; }
            set { 
                _SecondsLeft = value;
                if (PropertyChanged != null) {
                    PropertyChanged(this, new PropertyChangedEventArgs("SecondsLeft"));
                }
            }
        }
        private bool _StartFlashing;
        public bool StartFlashing {
            get { return _StartFlashing; }
            set { 
                _StartFlashing = value;
                if (PropertyChanged != null) {
                    PropertyChanged(this, new PropertyChangedEventArgs("StartFlashing"));
                }
            }
        }
    }
