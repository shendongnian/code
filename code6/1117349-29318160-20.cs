    public class OracleDatabaseHelper
    {
        public static DataTable GetDataTable(OracleCommand command, string connectionString)
        {
            DataTable dt = new DataTable();
            using (var connection = new OracleConnection(connectionString))
            {
                command.Connection = connection;
                connection.Open();
                dt.Load(command.ExecuteReader());
            }
            return dt;
        }
    }
