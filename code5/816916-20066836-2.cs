    public MainPage()
    {
        this.InitializeComponent();
    }
    protected override async void OnNavigatedTo(NavigationEventArgs e)
    {
        // allow other queued messages to be processed first
        // this may work as well: await Task.Yield();
        await Task.Delay(1);
        // now continue
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
            var dlg = new MessageDialog("You are totally screwed!");
            dlg.ShowAsync();
        }
    }
