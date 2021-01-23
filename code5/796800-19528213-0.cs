    private int rowNum;
    
    public int RowNum
    {
        get { return rowNum; }
        set
        {
            rowNum = value;
            RaisePropertyChanged("RowNum");
        }
    }
