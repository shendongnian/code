    public async void SynchronizeAsync<ToDoCategory>()
    {           
        var remoteTable = MobileServiceConnection.GetTable<ToDoCategory>();
    
        //Get new entities
        var newEntities = await remoteTable.Where(item => item.RemoteLastUpdated > currentTimeStamp).ToListAsync();
    }
