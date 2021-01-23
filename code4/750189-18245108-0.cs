    public int UnitCount
    {
        get { return _unitCount; }
        set
        {
            _unitCount = value;
            OnUnitCountChanged(new EventArgs());
            if(_unitCount == 0) { OnDepleted(new EventArgs()); }
        }
    }
