    // this would go in some service-level class
    public void ShowLoading(Func<bool> workToDo)
    {
        using(var load = new LoadingForm())
        {
            var completed = new AutoResetEvent(false);
            new Thread(delegate
                {
                    try
                    {
                        workToDo();
                    }
                    finally
                    {
                        completed.Set();
                    }
                });
            // show the loading form
            load.Show();
            // wait for the background worker
            while (!completed.WaitOne(100))
            {
                // just keep waiting
                // the timeout allows the UI to update
                // if you want to update the loading form with progress
                // or whatever, do that here
            }
        }
    }
