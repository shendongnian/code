    public async Task<ActionResult> Index() 
    {
        HttpResponseMessage aResponse = await aClient.PostAsync(theUri, theContent);
        //no error here
    }
