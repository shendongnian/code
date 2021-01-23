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
                        Application.Current.Dispatcher.BeginInvoke(
                            new Action(() =>
                            {
                                _Selection = ShowOtherDialog();
                                NotifyPropertyChanged("Selection");
                           }));                      
                    }
                    else
                    {
                        _Selection = value;
                        NotifyPropertyChanged("Selection");   
                    }
                   
                }
            }
        }
