    thisuser.FirstName = user.FirstName;
    thisuser.LastName = user.LastName;
    thisuser.UserName = user.UserName;
    thisuser.Password = user.Password;
    if (thisuser.Address == null)
    {
        thisuser.Address = new Address();   // Make sure this is the type 
                                            // that Address should be
                                            // This also assumes that Address is 1 to 1
    }
    thisuser.Address.City = user.Address.City;
