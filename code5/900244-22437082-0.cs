    //Makes a variable that contains your textbox value
    string FirstName = TxtFname.Text;
    
    //Inserts the FirstName variable into the db-table
    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            SqlCommand cmd = new SqlCommand();
    
            cmd.CommandText = "INSERT INTO YourTableName (YourFirstNameColumnName) VALUES (@FirstName)
    
            //Uses the FirstName variable and creates a new sql variable for use in the sql commandtext
            cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = FirstName;
    
            cmd.Connection = conn;
    
            conn.Open();
    
            cmd.ExecuteNonQuery();
    
            conn.Close();
