    DataTable dt = new DataTable();
    String sql = "SELECT id, password FROM users WHERE user = @user and password=@password"
    OleDbConnection connection = getAccessConnection();
    OleDbDataAdapter da = new OleDbDataAdapter(sql, connection);
    da.SelectCommand.Parameters.Add("@user", OleDbType.VarChar).Value = userNameText;
    da.SelectCommand.Parameters.Add("@password", OleDbType.VarChar).Value = password.Text;
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
    if(dt.Rows.Count == 1)
        return true; //username && password matches
    else if(dt.Rows.Count == 0)
        return false; // does not match
