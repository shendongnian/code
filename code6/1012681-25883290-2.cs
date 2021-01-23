     public string InsertUserDetails(UserDetails userInfo)
        {
            string Message;
            using (SqlConnection con = new SqlConnection())
            {   
                 con.ConnectionString = ConfigurationManager.ConnectionStrings["BCSConnectionString"].ConnectionString;
                 con.Open();      
                 using (SqlCommand cmd = new SqlCommand("select Id from [Person] where username = @session", con))
                 {
                      cmd.Parameters.AddWithValue("@session", userInfo.Session);
                      int iID = (int)cmd.ExecuteScalar();
                      
                      if(iID > 0) //check with reference to return ID
                      {
                         cmd.Parameters.Clear();
                         cmd.CommandText = "INSERT INTO Barcode (Id,Barcode,DateTime) values (@Id,@Barcode,@Datetime)";
                         cmd.Parameters.AddWithValue("@Id", iID);
                         cmd.Parameters.AddWithValue("@Barcode", userInfo.Barcode);
                         cmd.Parameters.AddWithValue("@Datetime", userInfo.Datetime);
                         cmd.Parameters.AddWithValue("@Vehicle", userInfo.Vehicle);
                         cmd.ExecuteNonQuery();
                         Message = userInfo.Barcode + "All of data Registered ";                         
                      }                  
                      else
                         Message = userInfo.Session + "The User Name has not been Registered...!";
                 }
            }
            return Message;
        }
