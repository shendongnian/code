    public static bool AccountAvailable(int AccountId)
    {
        bool accountavailable = false;
        try
        {            
    
            string queryTransaction = "Select Count(AccountID) FROM Accounts WHERE AccountID = " + AccountId.ToString() + " AND AccountUsed = 0";
    
            //grab a connection to the database
            Database database = DatabaseFactory.CreateDatabase();
    
            //create an instance of the command
            DbCommand command = database.GetSqlStringCommand(queryTransaction);
    
            object dataobject = command.ExecuteScalar();
    
            if (dataobject == null || string.IsNullOrEmpty(Convert.ToString(dataobject)))
            {
                accountavailable = false;
            }
    
            else if (Convert.ToInt32(dataobject) == 0)
            {
                accountavailable = false;
            }
    
            else if (Convert.ToInt32(dataobject) > 0)
            {
                accountavailable = true;
            }
    
            else
            {
                accountavailable = true;
            }
    
        }
    
        catch
        {
    
        }
        return accountavailable;
    }
