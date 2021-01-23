        if (String.IsNullOrWhiteSpace(username))
                throw new ArgumentException("username is null or whitespace");
        MembershipUser mu = Membership.GetUser(username);
        if (mu == null)
            throw new ArgumentNullException("Couldn't get a membership user for that username");
        string userEmail = mu.Email; // email is already a string, do not invoke Tostring() on it
         if (!string.IsNullOrEmpty(userEmail))
         {
             //do something
         }
