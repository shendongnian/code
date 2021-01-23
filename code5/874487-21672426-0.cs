    private SqlCommand Command()
    {
        cmd = new SqlCommand(QueryStr, Connection);
        return cmd;
    }
    private void Test()
    {
        using(SqlCommand command = Command())
        {
            // do your thing....
        }
    }
