    private ushort _offsetRoutine;
    private ushort _offsetString;
    
    public BaseClass()
    {
         _offsetRoutine= this.GetWord(Addresses.Header.OffsetRoutine);
         _offsetString= this.GetWord(Addresses.Header.OffsetString);
    }
    
    public ushort OffsetRoutine
    {
        get { return _offsetRoutine;}
    }
    
    public ushort OffsetString
    {
        get { return _offsetString;}
    }
