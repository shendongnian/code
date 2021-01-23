    public void Execute()
    {
        ...Do something
        //Encountered an error
        var doRollBackTask = WaitTillUserInput();
        doRollBackTask.ContinueWith(antecedent =>
        {
            if (antecedent.Result)
            { 
                //rollback here
            }
        });
    }
