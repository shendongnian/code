    private IEnumerable<UserBriefModel> SelectUserBriefModels(IEnumerable<User> users)
    {
        foreach (var user in users)
        {
            var membershipUser = Membership.GetUser(user.UserName);
            if (membershipUser != null)
            {
                yield return new UserBriefModel
                {
                    Username = user.UserName,
                    Fullname = user.FullName,
                    Email = membershipUser.Email,
                    Roles = user.UserName.GetRoles()
                };
            }
        }
    }
