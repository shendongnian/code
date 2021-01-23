         try
        {
            conn.Open();
           OracleDataReader reader = cmd.ExecuteReader();
            if (!reader.Read())
            { MessageBox.Show("User Name Not Found"); }
            if (!password.Equals(reader["password"].ToString())) 
            {
                 status=true;
                 MessageBox.Show("Incorrect Password");
            }
            else {
                    MessageBox.Show("Login Success");
                 }
        }catch(Exception ex) 
          { 
             MessageBox.Show(ex.ToString());
             status=false;
          }
