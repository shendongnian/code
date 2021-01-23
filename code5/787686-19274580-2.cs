    public async void Execute()
    {
        ...Do something
        //Encountered an error
        var doRollBack = await WaitTillUserInput();
        if(doRollBack)
        {
          //rollback here
        }
    }
