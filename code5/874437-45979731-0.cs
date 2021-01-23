    protected void Button1_Click(object sender, EventArgs e)
    {
    try
    {
    SqlConnection con = new SqlConnection(@"Data 
    Source=SANI2711\SQLEXPRESS;Initial Catalog=customer;Integrated 
    Security=True;");
    con.Open();
    DataTable dt = new DataTable();
    dt = DataExcel();
    if (dt.Rows.Count > 0)
    {
     for()
    }
    }
    catch(Exception ex)
    {
    Response.Write(ex);
    }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
    try
    {
    SqlConnection con = new SqlConnection(@"Data 
    Source=SANI2711\SQLEXPRESS;Initial Catalog=customer;Integrated 
    Security=True;");
    con.Open();
    DataTable dt = new DataTable();
    dt = DataExcel();
    if (dt.Rows.Count > 0)
    {
     SqlBulkCopy objbulk = new SqlBulkCopy(con);
     objbulk.DestinationTableName = "customer1";
     objbulk.ColumnMappings.Add("CustomerID", "CustomerID");
     objbulk.ColumnMappings.Add("City", "City");
     objbulk.ColumnMappings.Add("Country", "Country");
      objbulk.ColumnMappings.Add("PostalCode", "PostalCode");
      objbulk.WriteToServer(dt);
      }
     }
     catch (Exception ex)
     {
     Response.Write(ex);
     }
     }
     protected DataTable DataExcel()
     {
     DataTable dt = new System.Data.DataTable();
     try
     {
     string filenname=@"C:\Users\sani singh\Documents\Excel03.xls";
    string sWorkbook = "[Sheet1$]";
     string ExcelConnectionString=@"Provider=Microsoft.Jet.OLEDB.4.0;Data 
    Source="+filenname+";Extended Properties='Excel 8.0;HDR=Yes;IMEX=1'";
     OleDbConnection OleDbConn = new OleDbConnection(ExcelConnectionString);
     OleDbConn.Open();
     OleDbCommand OleDbCmd = new OleDbCommand(("SELECT * FROM " + sWorkbook), 
     OleDbConn);
     DataSet ds = new DataSet();
     OleDbDataAdapter sda = new OleDbDataAdapter(OleDbCmd);
     sda.Fill(ds);
     dt = ds.Tables[0];
     OleDbConn.Close();
     }
     catch(Exception ex) 
     {
     Response.Write(ex);
     }
     return dt;
     }
     }
     }
