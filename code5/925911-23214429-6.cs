    public async Task<ActionResult> Index()
    {
        Log("before GetAsync");
        await new HttpClient().GetAsync("http://www.example.com/")
            .ContinueWith(request =>
            {
                Log("ContinueWith");
                request.Result.EnsureSuccessStatusCode();
            }, 
            TaskContinuationOptions.AttachedToParent,
            CancellationToken.None,
            TaskScheduler.FromCurrentSynchronizationContext());
    
        return View();
    }
