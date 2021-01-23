    private bool _IsSettingUp;
        public bool IsSettingUp
        {
            get { return _IsSettingUp; }
            set 
            { 
                _IsSettingUp = value;
                //On property changed stuff
                OnPropertyChanged();
            }
        }
