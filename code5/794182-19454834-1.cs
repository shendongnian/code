    var sqlCom = new SqlCommand("authenticateLogin",sqlCon);
    sqlComm.CommandType = CommandType.StoredProcedure; //here
    sqlCom.Parameters.AddWithValue("@userName", userName);
    sqlCom.Parameters.AddWithValue("@password", encPassword);
    try
    {
        userRole = (short)sqlComm.ExecuteScalar();
        if (userRole > 0) return userRole;
    }
