    public bool isUserExist(string username,string password)
    {
        bool status=false;
        try
        {
            string connstring = "data source=test_db;user id=system;password=password;";
            string statementcmd = "SELECT * FROM register_user Where UserName=@username";
    
            using(OracleConnection conn = new OracleConnection(connstring))
           {
           
            using(OracleCommand cmd = new OracleCommand())
           {
            cmd.Connection = conn;
            cmd.Parameters.Add("@username", username);//add parameters before assigning it to CommandText
            cmd.CommandText = statementcmd;
            
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
               OracleDataReader reader = cmd.ExecuteReader();
               
    
                if (!reader.Read())
                { MessageBox.Show("User Name Not Found"); }
    
                if (!password.Equals(reader["password"].ToString()))
                     MessageBox.Show("Incorrect Password");
               
                }
                status=true;
    
            }
          }
    
         }
    
       }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString());
            status=false;
        }
    
    return status;
    
    }
