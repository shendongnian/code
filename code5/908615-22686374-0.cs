    class ClockViewModel : INotifyPropertyChanged
    {
        public ClockViewModel()
        {
            ...
            clock.Tick += new EventHandler(Clock_Tick);
        }
        private void Clock_Tick(object sender, EventArgs e)
        {
            Tick = string.Format("{0:HH:mm:ss}", DateTime.Now);
        }
        string _tick="";
        public string Tick
        {
            get
            {
                return _tick;
            }
            set
            {
                _tick = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Tick"));
            }
        }
    }
