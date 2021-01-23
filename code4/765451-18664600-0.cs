    public void AccessPermissions(User user)
    {
       if (user.Age < 18)
       {
           AcceessDenied();
       }
       else if (!user.IsRegistred)
       {
           AccessGrantLevel1();
       }
       else if (user.IsPowerfull)
       {
           AcessGrantLevel3();
       }
       else
       {
           AccessGrantLevel2();
       }
    }
