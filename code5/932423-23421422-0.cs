     private List<DataTable> readExcel(string strXLS)
    {
        //DataTable dtExcel = getExcelSheetTable();
        List<DataTable> SheetsData = new List<DataTable>();
        DataTable dtExcel = new DataTable();
        DataTable SocialMediaExcel = new DataTable();
        string connStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + strXLS + ";Extended Properties=Excel 12.0;";
        try
        {
            OleDbDataAdapter adpt = new OleDbDataAdapter("SELECT * FROM [Sheet1$]", connStr);
            adpt.Fill(dtExcel);
            SheetsData.Add(dtExcel);
           
            
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return SheetsData;
    }
