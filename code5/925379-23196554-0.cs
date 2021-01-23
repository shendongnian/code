    Task.Factory.StartNew(() =>{
       //Your code here
    }, _tokenSource.Token,
       TaskCreationOptions.None,
       TaskScheduler.Default)//Note TaskScheduler.Default here
    .ContinueWith(
            t =>
            {
                //finish...
                 if (OnFinishWorkEventHandler != null)
                     OnFinishWorkEventHandler(this, EventArgs.Empty);
            }
        , TaskScheduler.FromCurrentSynchronizationContext());
