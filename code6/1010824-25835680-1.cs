    public async override ViewDidLoad()
    {
        base.ViewDidLoad();
        if (!AppDelegate.IsInDesignerView)
        {
            await CallApi();
        }
    }
