    private ObservableCollection<Thing> _things;
    
    public ObservableCollection<Thing> Things
    {
        get { return _things; }
        private set 
        {
            if ( _things != value )
            {
                _things = value;
                OnPropertyChanged();
            }
        }
    }
    
    public PropertyChangedEventHandler PropertyChanged;
    private void OnPropertyChanged( [CallerMemberName] string propertyName = "" )
    {
        var evt = PropertyChanged;
        if ( evt != null)
        {
            evt( this, new PropertyChangedEventArgs( propertyName ) );
        }
    }
