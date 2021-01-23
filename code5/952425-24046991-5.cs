    [WebMethod]
    public static bool UserNameChecker(string newUserName)
    {
        string conString = @"user id=ejaz;password=ejaz;persistsecurityinfo=True;server=localhost;database=geospatialdb";
        MySqlConnection conn = new MySqlConnection(conString);
        MySqlDataReader reader = null;
        conn.Open();
        MySqlCommand command = new MySqlCommand("select owner_id from owner where owner_username = '" + newUserName + "';", conn);
        object found = command.ExecuteScalar();
        if (found != null)
            return true;
        else
            return false;
    } 
