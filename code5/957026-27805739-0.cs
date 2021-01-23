    bool isValid = false;
    if(user.Contains("@fullyqualifieddomain"))
    {
      isValid = Membership.ValidateUser(user, password)
    }
    else if(user.Contains("@"))
    {
      isValid = Membership.ValidateUser(Membership.GetUserNameByEmail(user),password);
    }
    else
    {
     isValid = Membership.ValidateUser(user+"fullyqualifieddomain");
    }
