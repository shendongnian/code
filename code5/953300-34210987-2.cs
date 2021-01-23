        public IEnumerable<T> ExecuteReader<T>(string sql, Func<DatabaseManager, T> conversionBlock)
        {
            Initialize();
            using (_connection)
            {
                _connection.Open();
                _command.CommandText = sql;
                _command.CommandType = CommandType.Text;
                if (_parameters.Count > 0)
                    AddParameters(_command, _parameters);
                _parameters.Clear();
                using (_reader = _command.ExecuteReader())
                {
                    while (_reader.Read())
                    {
                        yield return conversionBlock(this);
                    }
                }
            }
        }
        private static void AddParameters(DbCommand command, Dictionary<string, object> parameters)
        {
            foreach (var param in parameters)
            {
                command.Parameters.Add(CreateParameter(command, param.Key, param.Value));
            }
        }
        private static DbParameter CreateParameter(DbCommand command, string key, object value)
        {
            var parameter = command.CreateParameter();
            parameter.ParameterName = key;
            parameter.Value = value;
            return parameter;
        }
