    public SomeResult HandleWebRequest()
    {
        StartThing(); //not awaited - fire-and-forget
        //return a response
    }
    public async void StartThing()
    {
        for(var numTries = 0; numTries < 3; numTries++)
        {
            if(trySomethingThatMightNotWork)break;
            await Task.Delay(5000);
        }
    }
