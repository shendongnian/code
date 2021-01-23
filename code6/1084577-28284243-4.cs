    protected override async void OnStart()
    {
        try
        {
            await GetData(); 
        }
        catch (Exception e)
        {
            // handle e.
        }
    }
