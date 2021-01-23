    bool _isBeingSetByVM;
    public int Number
    {
        get { return _number; }
        set
        {
            if (_isBeingSetByVM)
            {
                // ViewModel has set the property
                // Do whatever you need to do...
                _isBeingSetByVM = false;
            }
            if (_number != value)
            {
                _number = value;
                OnPropertyChanged("Number");  // generate PropertyChanged event
            }
        }
    }
    int _number;
    void SomeMethodInVM()
    {
        _isBeingSetByVM = true;
        Number = 42;
    }
