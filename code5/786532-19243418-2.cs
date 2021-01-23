    private int myNumber;
    
    public string IsPair { get; protected set; }
    
    protected int MyNumber
    {
        get
        {
            return this.myNumber;
        }
    
        set
        {
            this.myNumber = value;
            this.IsPair = value % 2 == 0 ? "YES" : "NO";
            this.NotifyPropertyChanged("IsPair");
        }
    }
