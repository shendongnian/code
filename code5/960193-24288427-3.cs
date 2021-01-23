    model.Users = users
       .Where(u => Membership.GetUser(u.UserName) != null)
       .Select(u =>
        {
           return new UserBriefModel
             {
                 Username = u.UserName,
                 Fullname = u.FullName,
                 Email = Membership.GetUser(u.UserName).Email,
                 Roles = u.UserName.GetRoles()
              };
        })
        .ToList();
