    model.Users = users
        .SelectMany(u =>
        {
            var membershipUser = Membership.GetUser(u.UserName);
            return membershipUser != null
                ? new[]{ new UserBriefModel
                {
                    Username = u.UserName,
                    Fullname = u.FullName,
                    Email = membershipUser.Email,
                    Roles = u.UserName.GetRoles()
                }}
                : Enumerable.Empty<UserBriefModel>();
        }).ToList();
