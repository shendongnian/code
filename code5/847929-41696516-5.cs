    public static bool IsDbAffected(string query, string conn, List<SqlParameter> parameters = null)
    {
        var response = false;
        using (var sqlConnection = new SqlConnection(conn))
        {
            sqlConnection.Open();
            using (var transaction = sqlConnection.BeginTransaction("Test Transaction"))
            using (var command = new SqlCommand(query, sqlConnection, transaction))
            {
                command.Connection = sqlConnection;
                command.CommandType = CommandType.Text;
                command.CommandText = query;
                if (parameters != null)
                    command.Parameters.AddRange(parameters.ToArray());
                // ExecuteNonQuery() does not return data at all: only the number of rows affected by an insert, update, or delete.
                if (command.ExecuteNonQuery() > 0)
                {
                    transaction.Rollback("Test Transaction");
                    response = true;
                }
                transaction.Dispose();
                command.Dispose();
            }
        }
        return response;
    }
