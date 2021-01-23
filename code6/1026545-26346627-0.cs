        internal List<string> SqlQueryForRow(string query)
        {
            var conn = new SqlConnection(ConnectionString);
            var cmd = new SqlCommand(query, conn)
            {
                CommandText = query,
                CommandType = CommandType.Text,
                Connection = conn
            };
            conn.Open();
            var reader = cmd.ExecuteReader();
            // Data is accessible through the DataReader object here.
            // TODO add handling for more than one row; i.e. just take the first row
            var rowOfItems = new List<string>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    rowOfItems = GetColumnValuesForRow(reader);
                }
            }
            conn.Close();
            
            return rowOfItems;
        }
