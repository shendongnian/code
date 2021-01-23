     ChangeCollection<ItemChange> icc = service.SyncFolderItems(new FolderId(WellKnownFolderName.Calendar), PropertySet.FirstClassProperties, null, 512, SyncFolderItemsScope.NormalItems, sSyncState);
     sSyncState = icc.SyncState;
     if (icc.Count == 0)
     {
       Console.WriteLine("There are no item changes to synchronize.");
     }
     else
     {        
       foreach (ItemChange ic in icc)
       {
         **Appointment ap = (Appointment)ic.Item;**
       }
     }
