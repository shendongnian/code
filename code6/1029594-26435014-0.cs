    //This is very close to a standard INotifyPropertyChanged
    private int status_int = 0;
    private int Status
    {
        get { return status_int; }
        set
        {
           if (Status != value)
           {
               status_int = value;
               StatusChanged(value);
           }
        }
    }
