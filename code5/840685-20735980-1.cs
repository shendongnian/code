    public async Task Sync()
    {
        // lock our synctime
        var syncTime = DateTools.getNow();
        MiscStatus = "Sync starting at " + syncTime.ToString();
        var sync = new SyncLogic();
        var syncArgs = new SyncArguments();
        //populate syncArgs from ViewModel data
      
        //call the SyncAll as new Task so it will be executed as background operation
        //and "await" the result
        var syncResults = await Task.Factory.StartNew(()=>sync.SyncAll(syncArgs));
        //when the Task completes your execution will continue here and you can populate the   
        //ViewModel with results
         MiscStatus = String.Format("Sync finished at at {0}, total time taken {1}", 
            DateTools.getNow().ToString(), (DateTools.getNow() - syncTime).ToString());
    }
