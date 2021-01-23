    public void SaveUserFolder(UserFolder userFolder)
    {
        if (userFolder.UserFolderID == 0)         // new user folder
            _entities.UserFolders.Add(userFolder);
        else
        {
            _entities.UserFolders.Attach(userFolder);
            _entities.Entry(userFolder).State = EntityState.Modified;
        }
        _entities.SaveChanges();
    }
