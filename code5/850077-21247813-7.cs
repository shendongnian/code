    public class insert
    { 
        public static string insertCategories(DataTable table)
        {     
            SqlConnection objConnection = new SqlConnection();
              //As specified in the App.config/web.config file
            objConnection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["foo"].ToString();
            try
            {                                 
                objConnection.Open();
                var bulkCopy = new SqlBulkCopy(objConnection.ConnectionString);
                bulkCopy.DestinationTableName = "dbo.foo";
                bulkCopy.BulkCopyTimeout = 600;
                bulkCopy.WriteToServer(table);
                return "";
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                return "";
            }
            finally
            {
                objConnection.Close();
            }         
        }
    };
