    private SqlCommand Command()
    {
        cmd = new SqlCommand(QueryStr, Connection);
        return cmd;
    }
    private void Test()
    {
        // a using block is very safe, it will dispose the command 
        // even when exceptions are thrown.
        using(SqlCommand command = Command())
        {
            // do your thing....
        }
    }
