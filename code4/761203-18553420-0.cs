        public string[] GetColumnValues(string connectionString, string table, string column)
        {
            var connection = new SqlConnection(connectionString);
            var dataAdapter = new SqlDataAdapter(
                string.Format("SELECT [{0}].[{1}] FROM [{0}]", table, column), connection);
            var result = new List<string>();
            connection.Open();
            var dataSet = new DataSet();
            dataAdapter.Fill(dataSet);
            if (dataSet.Tables.Count > 0)
            {
                result.AddRange(from DataRow row in dataSet.Tables[0].Rows select row[0].ToString());
            }
            connection.Close();
            return result.ToArray();
        }
