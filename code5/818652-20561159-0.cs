    public sealed class TestClass : IBackgroundTask
    {
        void Run(IBackgroundTaskInstance taskInstance)
        {
            BackgroundTaskDeferral deferral = taskInstance.GetDeferral();
            updatelocation();
            deferral.Complete(); 
        }
    }
    
    public IAsyncOperation updatelocation()
    {
        return updatelocationHelper().AsAsyncOperation();
    }
     
    private async Task<string> updatelocationHelper()
    {
        var wcfClient = new MyWcfClient();
        var content = await wcfClient.updatelocationAsync(wcf_service_url_here);
     
        return content;
    }
