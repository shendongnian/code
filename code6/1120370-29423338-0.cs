    string original_dsn = "server=mysql.server.com,1433;database=pubdb;User Id={0};Password={1};"
    string dsn = String.Format(original_dsn, username, password);
	SqlConnection conn = new SqlConnection( dsn );
    try
    {
         conn.Open();
    }
    catch(SqlException e)
    {
        if (e.Number == 18487 || e.Number == 18488)
               SqlConnection.ChangePassword(dsn, newpassword);
               // Try login again here with new password
        else
               MessageBox.Show(e.Message);
    }
    finally 
    {
        conn.Close(); 
    }
    
