        IEnumerable<dynamic> TestData()
        {
            List<dynamic> results = new List<dynamic>();
            using (var connection = new NpgsqlConnection(ConnectionString()))
            {
                connection.Open();
                DbCommand command = (DbCommand)connection.CreateCommand();
                command.CommandText = "select 'A' union select 'B'";
                using (command)
                {
                    using (DbDataReader reader = command.ExecuteReader())
                    {
                        IEnumerable<string> columnNames = null;
                        while (reader.Read())
                        {
                            if (columnNames == null)
                                columnNames = GetColumnNames(reader);
                            results.Add(new EevaDynamicRecord(columnNames, reader));
                        }
                        //foreach (DbDataRecord record in reader)
                        //{
                        //    if (columnNames == null)
                        //        columnNames = GetColumnNames(record);
                        //    yield return new EevaDynamicRecord(columnNames, record);
                        //}
                    }
                }
            }
            return results;
        }
