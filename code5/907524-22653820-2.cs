    public async Task main()
    {     
     var TaskUsr = GetUserAsync(dev);
     var TaskOldCompany = GetOldCompanyAsync(dev);
     await Task.WhenAll(TaskUsr, TaskOldCompany);
    
     var usr = TaskUsr.Result;
     var oldCompanyName = TaskOldCompany.Result;
     ..... 
     use my two variables to insert a new entry into my localdb
    }
    private async Task<ut_User> GetUserAsync(ut_UserAPNdevices dev)
    {
     using (var dbSrc = new FSKWebInterfaceEntities())
      return dbSrc.ut_User.FirstOrDefault(x => x.UserID == dev.UserID);
    }
    private async Task<String> GetOldCompanyAsync(ut_UserAPNdevices dev)
    {
     using (var dbSrc = new FSKWebInterfaceEntities())
      return dbSrc.ut_User.FirstOrDefault(x => x.UserID == dev.UserID).Company;
    }
