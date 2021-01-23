    public string observationStr // repeat for stateStr
    {
        get { return _observationStr; }
        set { _observationStr = value; NotifyPropertyChanged(observationStr); 
            NotifyPropertyChanged(AreValuesChanged); }
    }
