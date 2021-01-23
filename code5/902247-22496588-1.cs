    public int WorkcodeId
    {
       get { return _workcodeId; }
       set
       {
       if(_workcodeId !=value)
      {
        _workcodeId = value;
        OnPropertyChanged("WorkcodeId");
        PopulateProcess();
      }
     }
    }
