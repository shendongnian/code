    MembershipUser user = Membership.GetUser("username"); // or however you want to retrive the MembershipUser object
    string password = Membership.GeneratePassword(12, 0); // generate a new password
    bool changePasswordSucceeded = user.ChangePassword(user.ResetPassword(), password); // reset the password
    
    if(changePasswordSucceeded)
    {
        // email logic here
    }
