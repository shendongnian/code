    private string _Selection;
        public string Selection
        {
            get { return _Selection; }
            set
            {
                if (_Selection != value)
                {
                    if (value == "Other")
                    {
                        _Selection = ShowOtherDialog();
                    }
                    else
                    {
                        _Selection = value;
                    }
                        
                    NotifyPropertyChanged("Selection");
                }
            }
        }
