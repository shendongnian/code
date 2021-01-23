    // define the query you want to execute
    string query = "SELECT TID, Password FROM Teacher WHERE TID = @ID AND Password = @Password";
    
    // establish connection and command objects, both wrapped into using(){} blocks to 
    // ensure proper disposal, even in case of an exception
    using (conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Name of connection string"].ConnectionString))
    using (SqlCommand command = new SqlCommand(query, conn))
    {
       // add paramters and set values
       command.Parameters.Add("@ID", SqlDbType.Int).Value = Convert.ToInt32(txtTID.Text);
       command.Parameters.Add("@Password", SqlDbType.VarChar, 50).Value = txtTPW.Text;
    
       // open connection
       conn.Open();
       // execute your reader
       using (SqlDataReader reader = command.ExecuteReader())
       {
           // you need to actually *read* from the reader here! What are you trying to do?
           // just check if that row with ID and password exist? Fetch some data?
           bool idExists = reader.HasRows();
           reader.Close();
       }
       
       conn.Close();
    }   
