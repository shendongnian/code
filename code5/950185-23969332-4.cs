    class Data : INotifyPropertyChanged
    {
        private double _RoE;
        public double RoE
        {
            get { return _RoE; }
            set 
            { 
                _RoE = value;
                if (value < 10)
                    RoEColor = new SolidColorBrush(Colors.Red);
                else if (value > 20)
                    RoEColor = new SolidColorBrush(Colors.Green);
                else
                    RoEColor = new SolidColorBrush(Colors.White);
                OnPropertyChanged("RoE");
            }
        }
    
        private SolidColorBrush _RoEColor;
        public SolidColorBrush RoEColor
        {
            get { return _RoEColor; }
            set { _RoEColor = value; OnPropertyChanged("RoEColor"); }
        }
        
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(name));
        }
    }
