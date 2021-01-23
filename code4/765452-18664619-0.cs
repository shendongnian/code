    if(user.Age<18)
    {
        AccessDenied();
        return;
    }
    if(user.IsPowerfull && user.IsRegistered)
    {
        AccessGrantLevel3();
        return;
    }
    if(user.IsRegistered)
    {
        AccessGrantLevel2();
        return;
    }
    AccessGrantLevel1();
    return;
