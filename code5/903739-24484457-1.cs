    public bool CheckCanDo()
    {
            if (!LocalAcess.HasNonSyncedItems())
            {
                return false;
            }
    
            // It might be !RemoteAcess.TryToSync() || LocalAcess.HasExpired
            // I did not really understand that part
            if (!RemoteAcess.TryToSync() && LocalAcess.HasExpired)
            {
                return false;            
            }
             
            LocalAcess.RefreshDateLastConnection();
            return true;             
    }
