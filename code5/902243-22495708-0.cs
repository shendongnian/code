     private int _workcodeId;
     public int WorkcodeId
     {
       get { return _workcodeId; }
       set
       {
          _workcodeId = value;
          OnPropertyChanged("WorkcodeId");
          if(WorkcodeID>0) PopulateProcess();
       }
    }
