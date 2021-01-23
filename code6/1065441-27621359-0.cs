    private readonly IProgress<int> progress;
    
    public MainViewModel()
    {
    	progress = new Progress<int>(value =>
    	{
    		ProgressPercent = value;
    	});
    }
    
    private async void ExecuteRunTests()
    {
    	ProgressPercent = 0;
    
    	var testItems = new TestItemListCreator().Execute(NetworkType);
    	var total = testItems.Count;
    
    	var count = 0;
    	foreach (var testItem in testItems)
    	{
    		count++;
    
    		var result = await new OAuthGetRequestExecutor().PerformGetRequest(testItem);
    		await ResultLogger.Log(result);
    
    		var percent = (count * 100) / total;
    		progress.Report(percent);
    	}
    }
