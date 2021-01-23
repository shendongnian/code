    private void btnSync_Click(object sender, EventArgs e)
    {
      //Create SyncAgent to have access to everything locally
      TaskTrackerDataEntityCacheSyncAgent syncAgent = new TaskTrackerDataEntityCacheSyncAgent();
      //=========================================================================================================
      //Determine the table and the direction for sync
      syncAgent.Employees.SyncDirection = SyncDirection.Bidirectional;
      //[Bidirectional( upload To the server first, then download from ther server )]
      //[DownloadOnly (Download from the server after full Sync )]
      //[Snapshot     ( Complete Refresh everything )]
      //[UploadOnly   ( upload to the server after full sync)]
      //=========================================================================================================
      //Create the ClientSyncProvider and ServerSyncProvider to use them in monitoring the failer in both sides
      TaskTrackerDataEntityCacheServerSyncProvider ssp = new TaskTrackerDataEntityCacheServerSyncProvider();
      TaskTrackerDataEntityCacheClientSyncProvider csp = new TaskTrackerDataEntityCacheClientSyncProvider();
      //=========================================================================================================
      //The SqlCeClientSyncProvider also includes a ConflictResolver property that you can use to resolve conflicts on the client. For each type of conflict, you can set a value from the ResolveAction enumeration:
      //ClientWins, ServerWins, FireEvent
      //There is no requirement to set the ConflictResolver for each type of conflict. 
      //You can resolve conflicts as you do on the server, by handling the ApplyChangeFailed event
      csp.ConflictResolver.ClientDeleteServerUpdateAction = ResolveAction.ClientWins;
      csp.ConflictResolver.ClientUpdateServerUpdateAction = ResolveAction.ClientWins;
      csp.ConflictResolver.ClientUpdateServerDeleteAction = ResolveAction.ClientWins;
      csp.ConflictResolver.ClientDeleteServerUpdateAction = ResolveAction.ClientWins;
      csp.ConflictResolver.ClientInsertServerInsertAction = ResolveAction.ClientWins;
      csp.ConflictResolver.StoreErrorAction = ResolveAction.ClientWins;
      csp.ApplyChangeFailed += SampleClientSyncProvider_ApplyChangeFailed;
      ssp.ApplyChangeFailed += SampleClientSyncProvider_ApplyChangeFailed;
      //=========================================================================================================
      //Add the  ClientSyncProvider and ServerSyncProvider to the syncAgnet
      syncAgent.LocalProvider = csp;
      syncAgent.RemoteProvider = ssp;   //it will help to generate exception when the client update refused 
      //=========================================================================================================
      //Call Sync method and recieve the a report about it
      SyncStatistics synStats = syncAgent.Synchronize();
      //=========================================================================================================
      //Display the sync stats
      MessageBox.Show(String.Format("Uploaded/Downloaded:{0}/{1}{4}", synStats.TotalChangesUploaded, synStats.TotalChangesDownloaded, synStats.UploadChangesFailed, synStats.DownloadChangesFailed, Environment.NewLine));
      //==============================================================
      //LoadData(); //It is function to reload the data 
    }
    //================================================================
    //This function will run the client update over server update
    private void SampleClientSyncProvider_ApplyChangeFailed(object sender, ApplyChangeFailedEventArgs e)
    {
      //Log event data from the client side.
      //EventLogger.LogEvents(sender, e);
      if (e.Conflict.ConflictType == ConflictType.ClientInsertServerInsert)
      {
        //e.Action = ApplyAction.Continue;          // ignore the conflict and continue synchronization.
        //e.Action = ApplyAction.RetryApplyingRow;    //retry applying the row. The retry will fail, and the event will be raised again if you do not address the cause of the conflict by changing one or both of the conflicting rows.
        e.Action = ApplyAction.RetryWithForceWrite; //retry with logic to force applying the change.
      }
      if (e.Conflict.ConflictType == ConflictType.ClientDeleteServerUpdate)
      {
        //e.Action = ApplyAction.Continue;          // ignore the conflict and continue synchronization.
        //e.Action = ApplyAction.RetryApplyingRow;    //retry applying the row. The retry will fail, and the event will be raised again if you do not address the cause of the conflict by changing one or both of the conflicting rows.
        e.Action = ApplyAction.RetryWithForceWrite; //retry with logic to force applying the change.
      } if (e.Conflict.ConflictType == ConflictType.ClientUpdateServerDelete)
      {
        //e.Action = ApplyAction.Continue;          // ignore the conflict and continue synchronization.
        //e.Action = ApplyAction.RetryApplyingRow;    //retry applying the row. The retry will fail, and the event will be raised again if you do not address the cause of the conflict by changing one or both of the conflicting rows.
        e.Action = ApplyAction.RetryWithForceWrite;//retry with logic to force applying the change.
      }
      if (e.Conflict.ConflictType == ConflictType.ClientUpdateServerUpdate)
      {
        //e.Action = ApplyAction.Continue;          // ignore the conflict and continue synchronization.
        //e.Action = ApplyAction.RetryApplyingRow;    //retry applying the row. The retry will fail, and the event will be raised again if you do not address the cause of the conflict by changing one or both of the conflicting rows.
        e.Action = ApplyAction.RetryWithForceWrite; //retry with logic to force applying the change.
        //Logic goes here.
      }
      if (e.Conflict.ConflictType == ConflictType.ErrorsOccurred)
      {
        //Logic goes here.
      }
    }
