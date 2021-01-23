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
    var command = new OracleCommand("select firstname from users where username=:username");
    command.Parameters.Add("username", UsernameLabel.Text.Trim());
    command.BindByName = true; //incredibly important if more than one parameter
    var dt = GetDataTable(command);
    DataView dv = dt.AsDataView();
    //now get the results. I prefer getting it from the DataTable instead of DataView. Easier to use Linq
    if(dt.Rows.Count > 0)
    {
        /* Below line requires extra reference to System.Data.DataSetExtensions */
        FirstNameLabel.Text = dt.AsEnumerable().First().Select(r => r.Field<string>("firstname"));
    }
    else
    {
        FirstNameLabel.Text = "not found";
    }
