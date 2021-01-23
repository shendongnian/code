    // pseudocode, not tested
    var usernames = Roles.GetUsersInRole("Administrator");
    var users = new List<MembershipUser>();
    var emails = new List<String>();
    foreach(var username in usernames){
        var user = MembershipProvider.GetUser(username, false);
        users.Add(user);
        emails.Add(user.Email);
    }
