    public void Notify()
    {
       var repositories = new IRepository[]
           {
             _repositoryBackupDeviceLocation,
             repositoryBackupHistory,
             ...
             ...,
             _repositoryBelongToSystem
           };
       foreach (var repo in repositories)
       {        
          repo.Save();
       }       
    } 
 
