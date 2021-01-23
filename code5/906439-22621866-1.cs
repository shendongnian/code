    public SomeResult HandleWebRequest()
    {
        StartThing(); //not awaited - fire-and-forget
        //return a response
    }
    public async void StartThing()
    {
        //await Task.Yield(); //return control to call site and finish asynchronously
        for(var numTries = 0; numTries < 3; numTries++)
        {
            if(trySomethingThatMightNotWork)break;
            await Task.Delay(5000);
        }
    }
