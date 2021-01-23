     public void confirm(string name, string pass)
        {
            string connection_sting = @"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\Senan\Documents\employees.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True";
            using (SqlConnection cnn = new SqlConnection(connection_sting)) 
            {
                cnn.Open();
        
                using (SqlCommand cmd = new SqlCommand("select * from employees where name=@Sid and pass=@password" , cnn))
                {
                    cmd.Parameters.AddWithValue("@Sid", name);
                    cmd.Parameters.AddWithValue("@password", pass);
                    SqlDataReader reader;
                    reader = cmd.ExecuteReader();
        
                    if (reader.HasRows)
                        MessageBox.Show("pass");
                    else
                        MessageBox.Show("fail");
                }
            }
      }
