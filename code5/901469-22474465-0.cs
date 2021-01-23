      try
      {
         using (var con = new SqlConnection(cc.connectDB()))
         using (var cmd = new SqlCommand("delete from log", con))
         using (var cmd1 = new SqlCommand(
                  "select * from Login where username=@UserName and password=@Password", con))
         {
            con.Open();
            cmd.ExecuteNonQuery();
            cmd1.Parameters.AddWithValue("@UserName", username.Text);
            cmd1.Parameters.AddWithValue("@Password", password.Text);
            // cmd1.ExecuteNonQuery(); -> Delete this line.
            using (var c = cmd1.ExecuteReader())
            {
               if (c.Read() == true)
               {
                  using (var cmd2 = new SqlCommand("Parameterize me too")
                  {
                     var count = (Int32) cmd2.ExecuteScalar();
                     if (count == 1)
                     {
                        using (var cmd3 = new SqlCommand("insert into log values (@AnotherParam)", con))
                        {
                           cmd3.ExecuteNonQuery();
                        }
                     }
                     else if (count == 2)
                     {
                        using (var cmd3 = new SqlCommand("insert into log values (@AnotherParam)", con))
                        {
                           cmd3.ExecuteNonQuery();
                        }
                     }
                     Menu shw = new Menu();
                     shw.Show();
                     this.Hide();
                  }
               }
               else
               {
                  MessageBox.Show("Login failed");
               }
            }
         }
         catch (Exception ee)
         {
            MessageBox.Show(ee.Message);
         }
