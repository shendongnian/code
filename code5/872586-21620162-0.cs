    using System.Data.SqlClient;
    using System.IO;
    using Microsoft.SqlServer.Management.Common;
    using Microsoft.SqlServer.Management.Smo;
     
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                string sqlConnectionString = "...";
                string script =File.ReadAllText("data.sql");
                SqlConnection conn = new SqlConnection(sqlConnectionString);
                Server server = new Server(new ServerConnection(conn));
                server.ConnectionContext.ExecuteNonQuery(script);
            }
        }
    }
