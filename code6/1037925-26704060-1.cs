    public static bool Insert(string userFName, string userLName, string userPass, DateTime userBirth, string userEmail, string userCountry)
    {
        try
        {
            OleDbHelper.fill("INSERT INTO UsersTable(userFName, userLName, userPass, userBirth, userEmail, userCountry, userActive) VALUES('" + userFName + "', '" + userLName + "', '" + userPass + "', " + userBirth + ", '" + userEmail + "', '" + userCountry + "', true)", "UsersTable");
        }
        catch
        {
            return false;
        }
        return true;
    }
