    static public void Insert(string _userName, string _password)
    {
        // ...
        SqlCeCommand commandInsert = new SqlCeCommand("INSERT INTO [Table](username, password) VALUES(@userName, @password)", connection); 
        commandInsert.Parameters.Add("@userName", _userName);
        commandInsert.Parameters.Add("@password", _password);
        // ...
    }
