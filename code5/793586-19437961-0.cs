    SqlConnection con = new SqlConnection(conectionString);
    string returnValue = string.Empty;
    string procedureName = "spGet_Data";
    SqlCommand sqlCmd = new SqlCommand(procedureName, con);
    sqlCmd.CommandType = CommandType.StoredProcedure;
