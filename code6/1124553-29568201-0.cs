    var user = BusinessLogic.GetUserByUserId(WebSecurity.CurrentUserId);
    if (user != null)
    {
        return user.CommunityId.HasValue "COMMUNITYID" : "Not set!";
    }
    // throw an ArgumentNullException (or something similiar) so that you know what happened
    throw new ArgumentNullExpception("user);
