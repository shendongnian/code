    public int setUserTimescale(DataObjects.UserDetails myUserDetails)
    {
        int ReturnValue = -1;
        SqlConnection myConnection = new SqlConnection(connectionString);
        SqlCommand myCommand = myConnection.CreateCommand();
        myCommand.CommandText = "User_Timescale_Up";
        myCommand.CommandTimeout = 120;
        myCommand.Connection = myConnection;
        myCommand.CommandType = CommandType.StoredProcedure;
        myCommand.Parameters.Add("UserID", SqlDbType.Int).Value = myUserDetails.UserID;
        myCommand.Parameters.Add("TimescaleID", SqlDbType.Int).Value = myUserDetails.TimescaleID;
        SqlParameter parameterReturnValue = new SqlParameter("@ReturnValue", SqlDbType.Int);
        parameterReturnValue.Direction = ParameterDirection.Output;
        myCommand.Parameters.Add(parameterReturnValue);
        try
        {
            myConnection.Open();
            myCommand.ExecuteNonQuery();
            // Get the return value
            ReturnValue = (int)myCommand.Parameters[2].Value;
        }
        catch (Exception e)
        {
            setDBError(myCommand, e.Message.ToString(), "User_Timescale_Up");
            ReturnValue = -2;
        }
        finally
        {
            myConnection.Close();
        }
        return ReturnValue;
    }
