    public class SqlOperations
    {
        private SqlConnection Connect()
        {
            ... Get SQL credentials here
            ... Open and return connection here
        }
        public bool InsertToTable(string columnName, string value)
        {
            using (var conn = Connect())
            {
                using (SqlCommand myCommand = new SqlCommand())
                {
                    myCommand.Connection = conn;
                    ... do your myCommand stuff here
                }
            }
        }
    }
