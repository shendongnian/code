        using System;
        using System.Collections.Generic;
        using System.Linq;
        using System.Web;
        using System.Web.UI;
        using System.Web.UI.WebControls;
        using Microsoft.ApplicationBlocks.Data;
        using System.Data.SqlClient;
        using System.Data;
        using AssamExitPollReport;
        using System.IO;
        using System.Drawing;
        using Spire.Xls;
        using System.Data.Sql;
    
        public partial class Default : System.Web.UI.Page
        {
            DataSet ds = new DataSet();
            clsdata obj = new clsdata();
            protected void Page_Load(object sender, EventArgs e)
            {
    
           string tablename = Request.QueryString["tablename"];
            
           // Response.ContentType = "text/xml";  //Set Content MIME Type. 
            Response.Write("<h3>Execution Started on " + DateTime.Now.ToLocalTime()+"</h3>");
            bool flg=false;
            if (tablename != null)
            {
                flg = BulkInsertDataTable(tablename);
                if (flg)
                    Response.Write("<br><h3>Successfully executed on " + DateTime.Now.ToLocalTime() + "</h3>");
                else
                    Response.Write("<br><h3>Oops! Something is wrong.</h3>");
            }
            else
                Response.Write("<br><h3>Oops! @parameter \"tablename\" is missing.</h3>");
        }
    
       
    
        //public bool BulkInsertDataTable(string tableName, DataTable dataTable)
        public bool BulkInsertDataTable(string tablename)
        {
            bool isSuccuss=true;
            try
            {
                string client = "Server=databasehost\\SQLEXPRESS;Database=dbname;Uid=username;Pwd=yourpassword;Trusted_Connection=no";
                ds = obj.Executedatasetcount("select_tablename");
                obj.ExecuteDataset("delete_temp", new object[] { tablename });
                using (SqlConnection destinationConnection = new SqlConnection(client))
                using (SqlBulkCopy bulkCopy = new SqlBulkCopy(destinationConnection))
                {
                    destinationConnection.Open();
                    bulkCopy.DestinationTableName = tablename;
                    bulkCopy.WriteToServer(ds.Tables[0]);
                    destinationConnection.Close();
                   
                }
            }
            catch (Exception ex)
            {
                isSuccuss = false;
            }
    
            return isSuccuss;
        }
    
        private void elseif(bool p)
        {
            throw new NotImplementedException();
        }
    }
