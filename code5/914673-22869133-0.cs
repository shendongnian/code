            //create a SqlConnection
            string connStr = "your connection string";
            SqlConnection conn = new SqlConnection(connStr);
            
            //Create a database reader
            conn.Open();
            //                          username table ↓    username textbox ↓
            string sql = "select * from users where username='" + usernameTextBox.Text + "'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            
            //Assume that the permission column has true for Admin and false for Basic user
            bool permission = false;
 
            while (reader.Read())
            {
                 //reads permission column
                 permission = reader["permission"].ToString();
            }
         
            if (permission == true)
            {
                 //go to admin menu
            }
            else
            {
                 //go to basic users menu
            }
           
            
                
