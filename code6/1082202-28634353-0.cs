           _BackroundSyncThread = new Thread(streamNotification.SynchronizeChangesPeriodically);       _BackroundSyncThread.Start();
    
     private void SynchronizeChangesPeriodically()
        {
          while (true)
          {
            try
            {
              // Get all changes from the server and process them according to the business
              // rules.
              SynchronizeChanges(new FolderId(WellKnownFolderName.Calendar));
            }
            catch (Exception ex)
            {
              Console.WriteLine("Failed to synchronize items. Error: {0}", ex);
            }
            // Since the SyncFolderItems operation is a 
            // rather expensive operation, only do this every 10 minutes
            Thread.Sleep(TimeSpan.FromMinutes(10));
          }
        }
        public void SynchronizeChanges(FolderId folderId)
        {
          bool moreChangesAvailable;
          do
          {
            Debug.WriteLine("Synchronizing changes...");
            // Get all changes since the last call. The synchronization cookie is stored in the _SynchronizationState field.
            // Only the the ids are requested. Additional properties should be fetched via GetItem calls.
            var changes = _ExchangeService.SyncFolderItems(folderId, PropertySet.FirstClassProperties, null, 512,
                                                           SyncFolderItemsScope.NormalItems, _SynchronizationState);
            // Update the synchronization cookie
            _SynchronizationState = changes.SyncState;
    
            // Process all changes
            foreach (var itemChange in changes)
            {
              // This example just prints the ChangeType and ItemId to the console
              // LOB application would apply business rules to each item.
              Console.WriteLine("ChangeType = {0}", itemChange.ChangeType);
              Console.WriteLine("Subject = {0}", itemChange.Item.Subject);
            }
            // If more changes are available, issue additional SyncFolderItems requests.
            moreChangesAvailable = changes.MoreChangesAvailable;
          } while (moreChangesAvailable);
        }
   
