     model.Users = users
           .SelectMany(u =>
           {
               var membership = Membership.GetUser(u.UserName);
    
               if (membership == null)
                   return Enumerable.Empty<UserBriefModel>();
    
               return new UserBriefModel[]
               {
                   new UserBriefModel()
                   {
                       Username = u.UserName,
                       Fullname = u.FullName,
                       Email = membership.Email,
                       Roles = u.UserName.GetRoles()
                   }
               };
           })
            .ToList();
