    // note: return could be "bool" or some kind of strongly-typed User object
    // but I'm not going to change that here
    public string[] GetValidUser(string dbUsername, string dbPassword)
    {
        // no need for the table to be a parameter; the other two should
        // be treated as SQL parameters
        string query = @"
    SELECT id,email,password FROM tbl_user
    WHERE email=@email AND password=@password";
        string[] resultArray = new string[3];
        // note: it isn't clear what you expect to happen if the connection
        // doesn't open...
        if (this.OpenConnection())
        {
            try // try+finally ensures that we always close what we open
            {
                using(MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("email", dbUserName); 
                    // I'll talk about this one later...
                    cmd.Parameters.AddWithValue("password", dbPassword); 
                    using(MySqlDataReader dataReader = cmd.ExecuteReader())
                    {
                        if (dataReader.Read()) // no need for "while"
                                               // since only 1 row expected
                        {
                            // it would be nice to replace this with some kind of User
                            //  object with named properties to return, but...
                            resultArray[0] = dataReader.GetInt32(0).ToString();
                            resultArray[1] = dataReader.GetString(1);
                            resultArray[2] = dataReader.GetString(2);
    
                            if(dataReader.Read())
                            { // that smells of trouble!
                                throw new InvalidOperationException(
                                    "Unexpected duplicate user record!");
                            }
                        }
                    }
                }
            }
            finally
            {
                this.CloseConnection();
            }
        }
        return resultArray;
    }
