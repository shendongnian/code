    using(SqlConnection con = new SqlConnection(cc.connectDB())
      {
        con.Open();
        using(SqlCommand cmd = new SqlCommand("delete from log", con))
          {
                cmd.ExecuteNonQuery();
          }
        using(SqlCommand cmd1 = new SqlCommand("select * from Login where username='" + username.Text + "' and password='" + password.Text + "'", con))
          {
             //You don't need this
             //cmd1.ExecuteNonQuery();
             using(SqlDataReader c = cmd1.ExecuteReader())
                  {
                    //other sruffs
                  }
           }
      }
