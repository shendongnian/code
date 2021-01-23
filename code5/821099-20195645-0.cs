    private Main4 _trenutno;
    public Main4 Trenutno
    {
        get
        {
            return _trenutno;
        }
        set
        {
            if (_trenutno == value)
            {
                return;
            }
            RaisePropertyChanging(TrenutnoPropertyName);
            _trenutno = value;
            RaisePropertyChanged(TrenutnoPropertyName);
        }
    }
