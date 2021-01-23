    protected bool IncreaseIsolatedStorageSpace(long quotaSizeDemand)
    {
        bool CanSizeIncrease = false;
        IsolatedStorageFile isolatedStorageFile = IsolatedStorageFile.GetUserStoreForApplication();
        //Get the Available space
        long maxAvailableSpace = isolatedStorageFile.AvailableFreeSpace;
        if (quotaSizeDemand > maxAvailableSpace)
        {
            if (!isolatedStorageFile.IncreaseQuotaTo(isolatedStorageFile.Quota + quotaSizeDemand))
            {
                CanSizeIncrease = false;
                return CanSizeIncrease;
            }
            CanSizeIncrease = true;
            return CanSizeIncrease;
        }
        return CanSizeIncrease;
    }
