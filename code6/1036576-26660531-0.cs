    System.Web.Security.MembershipUser membershipUser = System.Web.Security.Membership.GetUser(user.Name);
    if (membershipUser != null)
    {
        DateTime creationDate = membershipUser.CreationDate;
    }
