    public static DataTable GetDataTable(OracleCommand command)
    {
        DataTable dt = new DataTable();
        using (var connection = GetDefaultOracleConnection())
        {
            command.Connection = connection;
            connection.Open();
            dt.Load(command.ExecuteReader());
        }
        return dt;
    }
    
    public static OracleConnection GetDefaultOracleConnection()
    {
        return new OracleConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString); //just get a connection string from somewhere
    }
    
    //usage
    var command = new OracleCommand("select mycolumn from mytable where id=:id");
    command.Parameters.Add("id", 1); //passing in 1 as the ID, but could pull from a TextBox or similar
    command.BindByName = true; //incredibly important if more than one parameter
    var dt = GetDataTable(command);
    DataView dv = dt.AsDataView();
