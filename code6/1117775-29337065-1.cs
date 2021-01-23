    public WebApplication2.Models.MyAppUser GetData()
    {
       var currentUser = _db.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);
          
       
       return currentUser ;
    }
