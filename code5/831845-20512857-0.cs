        private DispatcherTimer _timer;
        
        public int MillisecondsToWait
        {
            get { return (int)GetValue(MillisecondsToWaitProperty); }
            set { SetValue(MillisecondsToWaitProperty, value); }
        }
        public DispatcherTimer Timer
        {
            get { return _timer; }
            set { _timer = value; }
        }
        // Using a DependencyProperty as the backing store for MillisecondsToWait.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MillisecondsToWaitProperty =
            DependencyProperty.Register("MillisecondsToWait", typeof(int), typeof(SmartButton), new PropertyMetadata(0));
        public SmartButton()
        {
            this.PreviewMouseLeftButtonUp+=OnPreviewMouseLeftButtonUp;
            this.PreviewMouseLeftButtonDown+=OnPreviewMouseLeftButtonDown;
            
        }
        private void OnPreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            ResetAndRemoveTimer();
            e.Handled = true;
        }
        private void OnPreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Timer = new DispatcherTimer(DispatcherPriority.Normal,this.Dispatcher)
            {
                Interval = TimeSpan.FromMilliseconds(MillisecondsToWait)
            };
            Timer.Tick += Timer_Tick;
            Timer.IsEnabled = true;
            Timer.Start();
            e.Handled = true;
        }
        void Timer_Tick(object sender, EventArgs e)
        {
            this.Command.Execute(this.CommandParameter);
            ResetAndRemoveTimer();
        }
        private void ResetAndRemoveTimer()
        {
            if (Timer == null) return;
            Timer.Tick -= Timer_Tick;
            Timer.IsEnabled = false;
            Timer.Stop();
            Timer = null;
        }
    }
