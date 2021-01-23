    public bool _state;
    public bool State
        {
            get { return _state; }
            set
            {
                if (value != _state)
                {
                    _state= value;
                    RaisePropertyChanged();
                }
            }
        }
 
        
