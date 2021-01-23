    private int _numberOfRows;
    public int NumberOfRows
        {
            get { return _numberOfRows; }
            set { _numberOfRows= value; RaisePropertyChanged("NumberOfRows"); }
        }    
    private int _numberOfColumns;
    public int NumberOfColumns
        {
            get { return _numberOfColumns; }
            set { _numberOfColumns= value; RaisePropertyChanged("NumberOfColumns"); }
        } 
    
    public MainViewModel()
    {
        NumberOfColumns = 3;
        NumberOfRows = 2;
    }
