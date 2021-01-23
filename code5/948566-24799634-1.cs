    public MainPage()
    {
        InitializeComponent();
    
        this.radDataBoundListBox.DataVirtualizationMode = DataVirtualizationMode.OnDemandAutomatic;
    
        this.radDataBoundListBox.DataRequested += this.OnDataRequested;
    }
    
    private void OnDataRequested(object sender, EventArgs args)
    {
        //TODO: download data items
    }
