    _connection = new SqlConnection(this._connectionString);
    public int Update(string query, Dictionary<string, string> commandParams)
        {
            int affectedRows = 0;
            using (SqlCommand command = new SqlCommand(query, _connection))
            {
                command.CommandType = CommandType.Text;
                foreach (var param in commandParams)
                {
                    if (param.Value == null)
                        command.Parameters.AddWithValue(param.Key, DBNull.Value);
                    else
                        command.Parameters.AddWithValue(param.Key, param.Value);
                }
                try
                {
                    _connection.Open();
                    affectedRows = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    _connection.Close();
                    command.Parameters.Clear();
                }
            }
            return affectedRows;
        }
