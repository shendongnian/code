    string connectionString = "Your connection";
    
    SqlConnection conn = new SqlConnection(connectionString);
    
    conn.Open();
    
    SqlCommand cmd = new SqlCommand(@"Select * from [User] WHERE UserName=@UserName AND Password=@Password AND Deleted=0", connectionString);
    
    cmd.Parameters.AddWithValue("@UserName", userName.Text);
    cmd.Parameters.AddWithValue("@Password", password.Text);
    
    DataSet dst = new DataSet();
    string tableName = "Your table Name";
    
    using(SqlDataAdapter adapter = new SqlDataAdapter(cmd))
    {
        adapter.Fill(dst, tableName);
    }
    
    conn.Close();
    
    if(dst.Tables[0].Rows.Count == 0)
    //show error
    
    if(dst.Tables[0].Rows.Count > 0)
    {
        if(Convert.ToInt32(dst.Tables[0].Rows[0]["IsAdmin"]) == 1)
            //load admin menu
        else
            // load normal user menu
    }
