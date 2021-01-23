    private readonly ObservableCollection<CounterReading> readings;
    public virtual ObservableCollection<CounterReading> Readings
    {
        get 
        { 
           if(_readings == null) 
           {
             _readings = new ObservableCollection<CounterReading>();
           }
           return readings; 
        }
        set { readings = value; }
    }
