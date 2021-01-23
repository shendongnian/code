    public DataTable Login(string u, string p)
    {
        var dataTable = new DataTable();
        var connectionString = "whatever";  // change this obviously :)
        var query = "select employeeid, username, password, firstname, lastname, employeerole from login where username = :username and password = :password";
        using (var oracleConnection = new OracleConnection(connectionString))
        {
            oracleConnection.Open();
            using (var oracleCommand = new OracleCommand(query, oracleConnection))
            {
                oracleCommand.Parameters.AddWithValue("username", u);
                oracleCommand.Parameters.AddWithValue("password", p);
                using (var oracleDataAdapter = new OracleDataAdapter(oracleCommand))
                {
                    oracleDataAdapter.Fill(dataTable);
                }
            }
            oracleConnection.Close();
        }
        return dataTable;
    }
