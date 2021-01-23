    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    namespace Working
    {
    class Program
    {
        static void Main(string[] args)
        {
            string DsQuery = "INSERT INTO table (param1,param2)VALUES(@param1,@param2)"; 
            string TgtServer = @".\SQLEXPRESS";
            DataSet dsServers = new DataSet();
            dsServers = ExecQuery(DsQuery, TgtServer, "InitialCatalog");
        }
        private static DataSet ExecQuery(string strQuery, string strServer, string strIC)
        {
            string connectionString = @"Data Source=" + strServer + ";Initial Catalog=" + strIC + ";Integrated Security=SSPI";
            string commandString = strQuery;
            DataSet ds = new DataSet();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(commandString, connectionString);
                da.Fill(ds, "Table");
            }
            catch (SqlException e)
            {
                Console.WriteLine("An SQL Exception Occured: " + e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("An General Exception Occured: " + e.Message);
            }
            return ds;
        }
    }
