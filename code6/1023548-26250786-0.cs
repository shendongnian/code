    using System.Web.Security;
    string[] userIds = { "username1", "username2", "username3" };
    
    var users = Membership.GetAllUsers()
        .Cast<MembershipUser>()
        .Where(x => userIds.Contains(x.UserName));
