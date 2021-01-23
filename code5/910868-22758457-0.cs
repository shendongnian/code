    public class SqlHelper
    {
        private readonly bool statisticsEnabled;
        public SqlHelper(bool statisticsEnabled)
        {
            this.statisticsEnabled = statisticsEnabled;
        }
        public T ExecuteSqalar<T>(SqlCommand command)
        {
            return Execute(command, c => (T) c.ExecuteScalar());
        }
        public void ExecuteNonQuery(SqlCommand command)
        {
            Execute(command, c => c.ExecuteNonQuery());
        }
        public List<IDataRecord> ExecuteReader(SqlCommand command)
        {
            return Execute<List<IDataRecord>>(command, c =>
            {
                var lsDataRecord = new List<IDataRecord>();
                using (SqlDataReader sqlDataReader = command.ExecuteReader())
                {
                    while (sqlDataReader.Read())
                    {
                        lsDataRecord.Add(sqlDataReader);
                    }
                }
            });
        }
        public T Execute<T>(SqlCommand command, Func<SqlCommand, T> processFunction)
        {
            using (var connection = new SqlConnection("CONNECTION_STRING"))
            {
                object result = new object();
                using (command)
                {
                    try
                    {
                        connection.StatisticsEnabled = statisticsEnabled;
                        connection.Open();
                        result = processFunction(command);
                    }
                    catch (Exception exception)
                    {
                        throw new Exception(String.Format("Не удалось выполнить команду: {0}",     command.CommandText), exception);
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
                if (connection.StatisticsEnabled)
                    AddDictionary(connection.RetrieveStatistics());
                return (T)result;
            }
        }
        private void AddDictionary(IDictionary retrieveStatistics)
        {
            // TODO:
        }
}
