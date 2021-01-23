    public string ConnectionString { get; set;}
    public SqlConnection GetConnection()
    {
        SqlConnection cn = new SqlConnection(ConnectionString);
        return cn;
    }
