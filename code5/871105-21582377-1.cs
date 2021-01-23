    private void UpdateData()
    {
        IsBusy = true;
        Task.Factory.CreateNew(()=>LongDBQuery())
                    .ContinueWith(t =>
                                  {
                                       if(t.Exception != null)
                                       {
                                            //Show Error Message
                                            return;
                                       }
                                       BudgetEntries = t.Result;
                                  }
    }, TaskScheduler.FromCurrentSynchronizationContext());
