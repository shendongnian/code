    public string Words
    {
        set
        {
            if(value != _words)
            {
                _words = value;
                OnPropertyChanged( );
            }
        }
    }
