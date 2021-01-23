    {	
        while (mySqlReader.Read())
        {
            if (UModel.Pwd != Convert.ToString(mySqlReader["UserPassword"]))
                Console.WriteLine("Query does not match");
            else  
                break;
        }
    
        // Closes the Reader and empties the Command object.
        mySqlReader.Close();
            
        try
        {
            // Updates the UserPassword in the Db.
            mySqlCommand = mySqlConnect.CreateCommand();
            mySqlCommand.CommandText = Database_MySQLDef.UPDATEUSERS + "UserPassword = '" + UModel.ConfirmPwd + "' WHERE UserName = '" + UModel.Name + "';";
            mySqlCommand.ExecuteNonQuery();
        }
        catch (MySqlException e)
        {
            Console.WriteLine(e.Message);
        }
    }
