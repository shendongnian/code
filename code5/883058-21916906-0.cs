    private int _sourceIndex;
    public int SourceIndex
    {
        get { return _sourceIndex; }
        set
        {
            _sourceIndex= value;
            NotifyPropertyChanged("SourceIndex");
        }
    }
    private List<ComboBoxItem> _sourceList;
    public List<ComboBoxItem> SourceList
    {
        get { return _sourceList; }
        set
        {
            _sourceList= value;
            NotifyPropertyChanged("SourceList");
        }
    }
    public ClientReports()
    {
        InitializeComponent();
        // Set the DataContext
        DataContext = this;
        // set the sourceIndex to 0
        SourceIndex = 0;
        // SourceList initialization
        source = ... // get your comboboxitem list
        source.Insert(0, new ComboBoxItem { Content = " - select - "});
        SourceList = source
    }
