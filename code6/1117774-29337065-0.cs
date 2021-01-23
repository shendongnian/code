    public WebApplication2.Models.MyAppUser GetData()
    {
       var currentUser = _db.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);
          
       var model = new WebApplication2.Models.MyAppUser()
       {
          /// Assign the property here
       };
       return model;
    }
