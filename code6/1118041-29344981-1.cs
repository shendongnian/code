    class ButtonViewModel: INotifyPropertyChanged
    {
        
        public ButtonViewModel(Visibility visibility)
        {
            _buttonVisibility = visibility;
        }
        private Visibility _buttonVisibility ;
        public Visibility ButtonVisibility
        {
            get { return _buttonVisibility; }
            set
            {
                _buttonVisibility = value;
                OnPropertyChanged("ButtonVisibility");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string p)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(p));
        }
    }
