    public int MyMethod(BigInteger executionId)
    {
        int status = -1;
        using (var connection = new SqlConnection(this.ConnectionString))
        {
            connection.Open();
            var command = new SqlCommand("select ... where execution_id=@execution_id", connection)     { CommandType = CommandType.Text };
            //BigInteger to Int64 conversion
            long execId = (long) executionId;
            var parameterExecutionId = new SqlParameter("@execution_id", SqlDbType.BigInt, execId) { SqlDbType = SqlDbType.BigInt };
            command.Parameters.Add(parameterExecutionId);
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    status = Convert.ToInt32(reader["status"]);
                }
            }
            connection.Close();
        }
        return status;    
    }
