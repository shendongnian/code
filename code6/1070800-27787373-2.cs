    public async void Execute(object parameter)
    {
        //this does not update the GUI immediately
        this.SetIsExecuting(true);
        //Delays this function executing, gives the UI a chance to pick up the changes
        await Task.Delay(500);
        //during this wait, button appears "clicked"
        Thread.Sleep(TimeSpan.FromSeconds(2)); //simulate first calculation
        this._bworker.RunWorkerAsync();
    }
