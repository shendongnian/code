    string commandText = "SELECT userdegre FROM Users WHERE username = @uname AND Password =@pwd";
    using(MySqlCommand cmd = new MySqlCommand( commandText ,conn))
    {                        
        cmd.Parameters.AddWithValue("@uname", myuser);
        cmd.Parameters.AddWithValue("@pwd", MypassMd5.ToString());
        var result = cmd.ExecuteScalar();
        if(result != null)
        {
              PublicVariables.UserId = myuser;
              PublicVariables.UserDegre = result.ToString();
        }
    }
