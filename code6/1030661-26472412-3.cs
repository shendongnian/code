    public static int ExecuteScript(string scripttext) // returns the number of statements executed
    {
        using(MySqlConnection conn = Database.Connect())
        using(MySqlCommand cmd = conn.CreateCommand())
        {
            cmd.CommandText = scripttext;
            ....
        }
    }
