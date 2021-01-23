    ContinuationManager _continuationManager;
    protected override void OnActivated(IActivatedEventArgs e)
    {
        base.OnActivated(e);
        _continuationManager = new ContinuationManager();
        var continuationEventArgs = e as IContinuationActivatedEventArgs;
        if (continuationEventArgs != null)
        {
            IWebAuthenticationContinuable azure = GetIWebAuthenticationContinuableInstance();
            _continuationManager.Continue(continuationEventArgs, azure);        
        }
    }
