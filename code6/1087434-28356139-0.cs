    private int _progress;
    public int progress
    {
        get { return _progress; }
        set
        {
            if (value != _progress)
            {
                _progress = value;
                OnPropertyChanged("progress");
            }
        }
    }
