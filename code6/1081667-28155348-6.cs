    /// <summary>
    /// Executes a database command with the specified connection and returns a data table synchronously.
    /// </summary>
    /// <param name="command">The command to execute.</param>
    /// <param name="connection">The connection to use.</param>
    /// <returns>A DataTable representing the command results.</returns>
    public static DataTable GetDataTable(SqlCommand command, SqlConnection connection)
    {
        DataTable dt = new DataTable();
        command.Connection = connection;
        using (connection)
        {
            connection.Open();
            dt.Load(command.ExecuteReader());
        }
        return dt;
    }
