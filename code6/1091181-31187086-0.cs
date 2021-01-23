    private IScalarQuerier _scalarQueryer;
    public DBHelper(IDbConnection connection, IScalarQuerier q)
    {
        _scalarQuerier = q;
        conn = (SqlConnection)connection;
        textCommand = new SqlCommand();
        textCommand.Connection = conn;
    }
