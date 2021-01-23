    DataTable dt = new DataTable();
    String sql = "SELECT id, password FROM users WHERE user = @user"
    OleDbConnection connection = getAccessConnection();
    OleDbDataAdapter da = new OleDbDataAdapter(sql, connection);
    da.SelectCommand.Parameters.Add("@user", OleDbType.VarChar).Value = userNameText;
    try
    {
       connection.Open();
       da.Fill(dt);
       connection.Close();
    }
    catch(OleDbException ex)
    {
       connection.Close();
       MessageBox.Show(ex.ToString());
    }
