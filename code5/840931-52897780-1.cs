    public string SaveStringSQL(string pQuery, string ConnectionString)
    {
        var connection = new Conexao(ConnectionString);
        connection.Open();
        SqlCommand command = new SqlCommand(pQuery, connection.Connection);
        var SavedString = (string)command.ExecuteScalar();
        connection.Close();
        return SavedString;
    }
