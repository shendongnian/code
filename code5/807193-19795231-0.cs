    class SomethingChanged : INotifyPropertyChanged
    {
        private Something sth;
        private string _oldName;
        private System.Timers.Timer _timer;
    
        public string Name { get { return sth.Name; }
    
        public SomethingChanged(Something Sth, double polingInterval)
        {
            sth = Sth;
            _oldName = Name;
            _timer = new System.Timers.Timer();
            _timer.AutoReset = false;
            _timer.Interval = polingInterval;
            _timer.Elapsed += timer_Elapsed;
            _timer.Start();
        }
    
        private void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if(_oldName != Name)
            {
               OnPropertyChanged("Name");
               _oldName = Name;
            }
    
            //because we did _timer.AutoReset = false; we need to manually restart the timer.
            _timer.Start();
        }
    
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            var tmp = PropertyChanged; //Adding the temp variable prevents a NullRefrenceException in multithreaded environments.
            if (tmp != null)
                tmp(this, new PropertyChangedEventArgs(propertyName));
        }
    }
