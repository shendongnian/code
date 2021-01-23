    public FastLogBox()
        {
            InitializeComponent();
            _logBoxText = new StringBuilder(150000);
            
            timer1.Interval = 20;
            timer1.Tick += timer1_Tick;
            timer1.Start();
            SetStyle(ControlStyles.DoubleBuffer, true);
        }
        void timer1_Tick(object sender, EventArgs e)
        {
            if (_timeToClear)
            {
                _logBoxText.Clear();
                _timeToClear = false;
            }
            if (_logQueue.Count <= 0) return;
            while (!_logQueue.IsEmpty)
            {
                string element;
                if (!_logQueue.TryDequeue(out element)) continue;
                {
                    _logBoxText.Insert(0, element + "\r\n");
                }
            }
            if (_logBoxText.Length > 150000)
            {
                _logBoxText.Remove(150000, _logBoxText.Length - 150001);
            }
            Text = _logBoxText.ToString();
        }
        public new void Clear()
        {
            _timeToClear = true;
            while (!_logQueue.IsEmpty)
            {
                string element;
                _logQueue.TryDequeue(out element);
            }
        }
        public void AddToQueue(string message)
        {
            _logQueue.Enqueue(message);
        }
    }
