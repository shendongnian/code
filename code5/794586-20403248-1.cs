    using System;
    using System.Data;
    using System.Configuration;
    using System.Linq;
    using System.Web;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;
    using System.Web.UI.WebControls.WebParts;
    using System.Xml.Linq;
    using Microsoft.ApplicationBlocks.Data;
    
    namespace AssamExitPollReport
    {
        public class clsdata
        {
           // string conn = "Data Source=ADMIN-B19C3BADF;Initial Catalog=bazarkhodro;Integrated Security=True";
           
           
    
            public DataSet Executedataset(string spName)
            {
                return SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.ConnectionStrings["conn1"].ConnectionString, CommandType.StoredProcedure, spName);
            }
            public DataSet ExecuteDataset(string spName, object[] values)
            {
                return SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.ConnectionStrings["conn1"].ConnectionString, spName, values);
            }
            public DataSet ExecuteDataset(string spName, object[] values, string conn)
            {
                return SqlHelper.ExecuteDataset(conn, spName, values);
            }
            public int ExecuteNonQuery(string spName, object[] values, string conn)
            {
                int i = 0;
                try
                {
    
                    i = SqlHelper.ExecuteNonQuery(conn, spName, values);
    
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                return i;
    
            }
    
            public int ExecuteScaler(string spName, object[] values)
            {
                int i = 0;
                try
                {
                    i = Convert.ToInt32(SqlHelper.ExecuteScalar(System.Configuration.ConfigurationManager.ConnectionStrings["conn"].ConnectionString, spName, values));
                }
                catch (Exception)
                {
    
                    throw;
                }
                return i;
            }
    
            public int ExecuteScaler(string spName, object[] values, string conn)
            {
                int i = 0;
                try
                {
                    i = Convert.ToInt32(SqlHelper.ExecuteScalar(conn, spName, values));
    
                }
                catch (Exception)
                {
    
                    throw;
                }
                return i;
            }
    
        }
    }
