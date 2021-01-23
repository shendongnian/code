    public SqlCommand(string cmdText, SqlConnection connection) : this()
    {
        this.CommandText = cmdText;
        this.Connection = connection;
    }
