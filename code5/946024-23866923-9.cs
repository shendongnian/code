        var model = _db.UserProfiles.Select(u => new UserViewModel()
        {
            UserName = u.UserName,
            UserRoles = u.UserRoles.Select(ur=>ur.RoleName)
        }).ToList();
