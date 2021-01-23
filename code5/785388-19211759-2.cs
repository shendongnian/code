     private ObservableCollection<ClassMM> _topp
    public ObservableCollection<ClassMM> topp
            {
                get { return _topp; }
                set
                {
                    if (value != _topp)
                    {
                        _topp = value;
                        NotifyPropertyChanged("topp");
                    }
                }
            }
