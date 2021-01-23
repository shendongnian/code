    public TraceChartView()
    {
        InitializeComponent();
    
        CopyToClipboardCommand = new RelayCommand(DoCopyToClipboard);
    }
