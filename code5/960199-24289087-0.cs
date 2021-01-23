    model.Users = users
        .Select(user => new
        {
            user,
            membershipUser = Membership.GetUser(user.UserName)
        })
        .Where(pair => pair.membershipUser != null)
        .Select(pair => new UserBriefModel
        {
            Username = pair.user.UserName,
            Fullname = pair.user.FullName,
            Email = pair.membershipUser.Email,
            Roles = pair.user.UserName.GetRoles()
        })
        .ToList();
