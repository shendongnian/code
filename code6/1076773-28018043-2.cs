    public partial class ExcelAdapter : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String sConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + Server.MapPath("ExcelCSTest.xls") + ";" + "Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=1\"";
    
            using (OleDbConnection objConn = new OleDbConnection(sConnectionString))
            {
                objConn.Open();
                var sSQL = "SELECT * FROM [Sheet1$A1:D14]";
                OleDbCommand objCmdSelect = new OleDbCommand(sSQL, objConn);
                objCmdSelect.CommandType = CommandType.Text;
                DataSet objDataset = new DataSet();
                OleDbDataAdapter objAdapter = new OleDbDataAdapter(objCmdSelect).Fill(objDataset);
                objConn.Close();
            }
        }
    }
