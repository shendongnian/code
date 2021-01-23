    using System.Data.SqlClient;
    using Microsoft.SqlServer.Management.Smo;
    
    namespace SQLLogsToText
    {
        internal class Program
        {
            private static void Main(string[] args)
            {
                var sqlConnection = new SqlConnection(@"Integrated Security=SSPI; Data Source=(local)\SQLEXPRESS");
                var serverConnection = new Microsoft.SqlServer.Management.Common.ServerConnection(sqlConnection);
                var server = new Server(serverConnection);
                var errorLogPath = server.ErrorLogPath;
    
                // Enumerate Files
            }
        }
    }
