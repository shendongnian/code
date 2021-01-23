    public void AccessPermissions(User user)
    {
        if (!user.Age >= 18)
        {
            AcccessDenied();
        }
        if (!user.IsRegistered)
        {
            AccessGrantLevel1();
        }
        if (!user.IsPowerfull)
        {
            AccessGrantLevel2();
        }
        AccessGrantLevel3();
    }
