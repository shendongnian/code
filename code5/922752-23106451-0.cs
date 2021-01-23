    using(SqlConnection con = new SqlConnection(strConnString))
    using(SqlCommand com = con.CreateCommand())
    {
       string checkuser = "select COUNT(*) from [User] where UserName = @user";
       com.CommandText = checkuser;
       com.Parameters.AddWithValue("@user", txtusername.Text);
       int temp = (int)com.ExecuteScalar();
       if(temp == 1)
       ///
    }
