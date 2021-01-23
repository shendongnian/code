    public static bool checkExists(string Query)
    {
        checkConnection();
        try { return new MySqlCommand(Query + " LIMIT 1", dbConnection).ExecuteReader().HasRows; }
        catch
        {
            return false;
        }
    }
