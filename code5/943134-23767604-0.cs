    public Form1()
            {
                InitializeComponent();
    
                var observable = Observable.FromEventPattern(
                    s => textBox1.TextChanged += s, s => textBox1.TextChanged -= s)
                    //make sure we are on the UI thread
                    .ObserveOn(SynchronizationContext.Current)
                    //immediately set it to false
                    .Do(_ => UpdateEnabledStatus(false))
                    //throttle for one second
                    .Throttle(TimeSpan.FromMilliseconds(1000))
                    //again, make sure on UI thread
                    .ObserveOn(SynchronizationContext.Current)
                    //now re-enable
                    .Subscribe(_ => UpdateEnabledStatus(true));
            }
    
            private void UpdateEnabledStatus(bool enabled)
            {
                button1.Enabled = enabled;
            }
