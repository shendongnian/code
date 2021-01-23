    public bool CheckCanDo()
    {
        if (LocalAcess.HasNonSyncedItems())
        {
            if (RemoteAcess.TryToSync())
            {
                LocalAcess.RefreshDateLastConnection();
                return  true;
            }
            else
            {
                if (LocalAcess.HasExpired)
                {
                    return false;
                }
            }
        }
        return true;
    }
