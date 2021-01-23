    // using
    object syncObj = new object();
    bool operationPending = false;
    while (operation)
    {
       // ... Do work
       // Update, but only if there isn't a pending update
       lock(syncObj)
       {
           if (!operationPending)
           {
               operationPending = true;
               control.BeginInvoke(new Action( () =>
               {
                   // Update gauges
                   lock(syncObj)
                      operationPending = false;
               }));
           }
       }
    }
    // Update at the end (since you're last update might have been skipped)
    control.Invoke(new Action(UpdateGuagesCompleted));
