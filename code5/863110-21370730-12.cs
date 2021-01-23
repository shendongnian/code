    try
    {
        SqlConnection con = new SqlConnection(....);
        // Do stuff with the database connection
    }
    catch(SqlException sex)
    {
         // Log this
         throw new UserSomethingException("A connection to the database could not be established");
    }
