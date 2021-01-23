    DataContractStorageSerializer xmlStorage = new DataContractStorageSerializer(this.StorageFolder);
    var readAttempt = await xmlStorage.TryReadObjectAsync<UserProfile>(userName, UserProfileFilename);
            
    try
    {
        UserProfile user;
        if (readAttempt.TryResult(out user))
        {
            // Do something with user.
        }
        else
        {
            // No user in the persisted file.
        }
    }
    catch (FileNotFoundException fnfe)
    {
        // ...
    }
