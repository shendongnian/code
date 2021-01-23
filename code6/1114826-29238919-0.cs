    var currentUser = DbCtx.Users.FirstOrDefault(u => u.UserName == User.Identity.Name).Select(u => new MyAppUser
    {
        Id = u.Id,
        UserName = u.UserName // etc...
    });
