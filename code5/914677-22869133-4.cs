            //create a SqlConnection
            string connStr = "your connection string";
            SqlConnection conn = new SqlConnection(connStr);
            
            //Create a database reader
            conn.Open();
            
            //create a new SqlParameter
            //                        your username textbox ↓    
            myparm = new SqlParameter("@username",usernameTextBox.Text);
            
            //                     your username column ↓    
            string sql = "select * from users where username=@username";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            
            //Assume that the permission column has true for Admin and false for Basic user
            bool permission = false;
 
            while (reader.Read())
            {
                 //reads permission column
                 permission = Convert.ToBoolean(reader["permission"]);
            }
            
            conn.Close();
         
            if (permission == true)
            {
                 //go to admin menu
            }
            else
            {
                 //go to basic users menu
            }
           
            
                
