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
                    //You don't need these lines - this is probably the line of error
                    //SqlCommand cmd2 = new SqlCommand("select typeid from Login where username='" + username.Text + "' and password='" + password.Text + "'", con);
                    //Int32 count = (Int32)cmd2.ExecuteScalar();
                    INT32 count = Convert.ToInt32(c["typeid"].ToString());
                    //other sruffs
                  }
           }
      }
