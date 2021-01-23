    // using System.Data.OleDb
    OleDbConnection ExcelConection = null;
    OleDbCommand ExcelCommand = null;
    OleDbDataReader ExcelReader = null;
    OleDbConnectionStringBuilder OleStringBuilder = null;
    
    try
    {
        OleStringBuilder =
            new OleDbConnectionStringBuilder(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\MyExcel.xls;Extended Properties='Excel 8.0;HDR=Yes;IMEX=1';");
        OleStringBuilder.DataSource = MapPath(@"~\App_Datav\MyExcelWorksheet.xls");
    
        ExcelConection = new OleDbConnection();
        ExcelConection.ConnectionString = OleStringBuilder.ConnectionString;
    
        ExcelCommand = new OleDbCommand();
        ExcelCommand.Connection = ExcelConection;
        ExcelCommand.CommandText = "Select * From [Sheet1$]";
    
        ExcelConection.Open();
        ExcelReader = ExcelCommand.ExecuteReader();
    
        GridView1.DataSource = ExcelReader;
        GridView1.DataBind();
    }
    catch (Exception Args)
    {
        LabelErrorMsg.Text = "Could not open Excel file: " + Args.Message;
    }
    finally
    {
        if (ExcelCommand != null)
            ExcelCommand.Dispose();
        if (ExcelReader != null)
            ExcelReader.Dispose();
        if (ExcelConection != null)
            ExcelConection.Dispose();
    }
