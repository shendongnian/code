    public static string GetTicket(string supportRef)
    {
     try
     {
        string returnValue = string.Empty;
        DB = Connect();
        DBCommand = connection.Procedure("getTicket");
        DB.AddInParameter(DBCommand, "@SupportRef", DbType.String, supportRef);
        var myReader = DBCommand.ExecuteReader();
        while (myReader.Read())
        {
            returnValue = myReader.GetString(0);
        }
        return returnValue;
     }
     catch (Exception ex)
     {
        throw ex;
     }
    }
