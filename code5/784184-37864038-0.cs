    public int ExecuteNonQuery(MySqlParameterCollection oMySqlParameterCollection, string storedProcedure)
        {
            int affectedRows = 0;
            _oMySqlConnection.Open();
            MySqlCommand oMySqlCommand = new MySqlCommand
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = storedProcedure,
                Connection = _oMySqlConnection
            };
            foreach (var mysqlParamater in oMySqlParameterCollection)
            {
                oMySqlCommand.Parameters.Add(mysqlParamater);
            }
            affectedRows = oMySqlCommand.ExecuteNonQuery();
            _oMySqlConnection.Close();
            return affectedRows;
        }
