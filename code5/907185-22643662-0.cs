    TBL_LogIn newUser = hrmsDb.TBL_LogIn.Where(x => x.EmployeeID == inputEmployeeID).FirstOrDefault();
    if (newUser != null)
    {
        AddLogInInfo(newUser);
        hrmsDb.SaveChanges();
    }
    else
    { }
