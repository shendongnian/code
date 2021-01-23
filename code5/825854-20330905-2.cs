    nonqueryCommand.CommandType = CommandType.Text;
    nonqueryCommand.CommandText = "INSERT tblLoginLogTable (UserName, LoggedInDate, LoggedInTime) VALUES (@UserName, @LoggedInDate, @LoggedInTime); " + 
                                  "SELECT @ID = SCOPE_IDENTITY()";
    nonqueryCommand.Parameters.AddWithValue("@UserName", txtUserName.Text);
    nonqueryCommand.Parameters.AddWithValue("@LoggedInDate", DateTime.Now);
    nonqueryCommand.Parameters.AddWithValue("@LoggedInTime", DateTime.Now);
    nonqueryCommand.Parameters.Add("@ID",SqlDbType.Int).Direction = ParameterDirection.Output;
    thisConnection.Open();
    nonqueryCommand.ExecuteNonQuery(); 
    int id = nonqueryCommand.Parameters["@ID"];
