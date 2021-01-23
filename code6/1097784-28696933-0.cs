    SqlConnection sqlConn = new SqlConnection(connection string here);
    SqlCommand sqlComm = new SqlCommand();
    sqlComm = sqlConn.CreateCommand();
    sqlComm.CommandText = @"UPDATE User_tbl SET LastSeen=GetDate() WHERE UserName='@userName'";
    sqlComm.Parameters.Add("@userName", SqlDbType.VarChar);
    sqlComm.Parameters["@userName"].Value = txtUserName.Text;
    sqlConn.Open();
    sqlComm.ExecuteNonQuery();
    sqlConn.Close();
