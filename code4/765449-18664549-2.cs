    public void AccessPermissions(User user)
    {
        if (!(user.Age >= 18))
        {
            AcccessDenied();
        }
        else if (!user.IsRegistered)
        {
            AccessGrantLevel1();
        }
        else if (!user.IsPowerfull)
        {
            AccessGrantLevel2();
        }
        else
        {
            AccessGrantLevel3();
        }
    }
