    protected override void OnStart()
    {
        MyService.GetDataAsync().ContinueWith(t => 
        {
            try 
            { 
                t.Wait();
            }
            catch (Exception e)
            {
                // handle exceptions
            }
        });
    }
