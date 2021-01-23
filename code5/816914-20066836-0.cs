    public MainPage()
    {
        this.InitializeComponent();
    }
    protected override async void OnNavigatedTo(NavigationEventArgs e)
    {
        await fillChartsObject();
    }
    private async void fillChartsObject()
    {
        try
        {
            var response = await MyClient.fetchContentAsync();
            responseString = response.ToString();
        }
        catch
        {
            var dlg = new MessageDialog("You are totaly screwed!");
            dlg.ShowAsync();
        }
    }
