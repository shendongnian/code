     public string InsertUserDetails(UserDetails userInfo)
        {
            string Message;
            using (SqlConnection con = new SqlConnection())
            {   
                 con.ConnectionString = ConfigurationManager.ConnectionStrings["BCSConnectionString"].ConnectionString;
                 con.Open();
                 bool exists = false;
                 int iID;
                 using (SqlCommand cmd = new SqlCommand("select Id from [Person] where username = @session", con))
                 {
                      cmd.Parameters.AddWithValue("@session", userInfo.Session);
                      iID = (int)cmd.ExecuteScalar();                  
                 }
                 if (exists)
                      Message = userInfo.Session + "The User Name has not been Registered...!";
                 else
                 {
                      using (SqlCommand cmd = new SqlCommand("INSERT INTO Barcode (Id,Barcode,DateTime) values (@Id,@Barcode,@Datetime)", con))
                      {
                           cmd.Parameters.AddWithValue("Id", iID);
                           cmd.Parameters.AddWithValue("Barcode", userInfo.Barcode);
                           cmd.Parameters.AddWithValue("Datetime", userInfo.Datetime);
                           cmd.Parameters.AddWithValue("Vehicle", userInfo.Vehicle);
                           cmd.ExecuteNonQuery();
                           Message = userInfo.Barcode + "All of data Registered ";
                      }
                 }
            }
            return Message;
        }
