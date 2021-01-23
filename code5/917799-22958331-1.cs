    string CS = ConfigurationManager.ConnectionStrings["ABCD"].ConnectionString;
    using(SqlConnection con = new SqlConnection(CS))
    {
        try{
        con.Open();
        SqlCommand cmd = new SqlCommand("spChangePassword", con);
        cmd.CommandType = CommandType.StoredProcedure;
    
        cmd.Parameters.AddWithValue("@Email",txtEmail.Text);
        cmd.Parameters.AddWithValue("@Passwordd", txtPassword.Text);
        cmd.ExecuteNonQuery();
        }
        catch(SqlException ee)
        {
          ...
        }
    }
