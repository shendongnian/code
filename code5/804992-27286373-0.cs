    // i just typed this off the top of my head, so be forewarned...  :)
    lock(someLockingObj)
    {
        Application.Current.Dispatcher.BeginInvoke(new Action(()=>
        {
           ... update here....
        }));
    }
