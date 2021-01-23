    public static IDataRecord GetDataRecord(string Query, Dictionary<string, object> Parameters, CommandType CommandType = CommandType.Text)
    {
        IDataRecord Record = null;
        using (MySqlConnection Connection = CreateConnection())
        {
            using (MySqlCommand cmd = new MySqlCommand(Query, Connection))
            {
                cmd.CommandType = CommandType;
                foreach (var Parameter in Parameters)
                {
                    cmd.Parameters.AddWithValue(Parameter.Key, Parameter.Value);
                }
                Connection.Open();
                using (MySqlDataReader Reader = cmd.ExecuteReader())
                {
                    if (Reader.Read())
                    {
                        Record = Reader;
                    }
                }
                Connection.Close();
            }
        }
        return Record;
    }
