    public string NodeName
    {
         get { return _nodeName ?? string.Empty; }
         set
         {
             _nodeName = value;
             NotifyPropertyChange(() => NodeName);
         }
    }
