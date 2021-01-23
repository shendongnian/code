    public bool InsertUser(string userFName, string userLName, string userPass, DateTime userBirth, string userEmail, string userCountry)
    {
        if (UsersDAL.Insert(userFName, userLName, userPass, userBirth, userEmail, userCountry))
        {
            return true;
        }
        return false;
    }
