    using System.Data.SqlClient;
    using Microsoft.SqlServer.Management.Smo;
    
    namespace SQLLogsToText
    {
        internal class Program
        {
            private static void Main(string[] args)
            {
                string errorLogPath = null;
    
                using (var sqlConnection = new SqlConnection(@"Integrated Security=SSPI; Data Source=(local)\SQLEXPRESS"))
                {
                    var serverConnection = new Microsoft.SqlServer.Management.Common.ServerConnection(sqlConnection);
                    var server = new Server(serverConnection);
                    errorLogPath = server.ErrorLogPath;
                }
    
                if (errorLogPath != null)
                {
                    // Enumerate Files
                }
            }
        }
    }
