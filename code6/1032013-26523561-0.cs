    var loadedAdminGroupUserIDs = adminGroupUserID.ToArray();
    using(MainEntities mainContext = new MainEntities())
    {
        return (from member in mainContext.aspnet_Membership
                where loadedAdminGroupUserIDs.Contains(member.UserId)
                select new
                {
                    FullName = member.FirstName + " " + member.LastName,
                    UserName = (from user in mainContext.aspnet_Users
                                where user.UserId == member.UserId
                                select user.UserName)
                }).ToList(); 
    }
