    private string meterName;
    public string MeterName
    {
       get
       {
          return meterName;
       }
       set
       {
          if(meterName != value)
          {
             meterName = value;
             OnPropertyChanged("MeterName");
          }
       }
    }
