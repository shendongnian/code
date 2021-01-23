    protected void btnExcelCheckListDownload_Click(object sender, EventArgs e)
    {
        DataSet dsTest = new DataSet();
        var db = new BillingEntities();
        var query = (from u in db.v_Checklist select u).AsQueryable();
        DataTable dt =  query.CopyToDataTable();
        dsTest.Tables.Add(dt);
        ExcelLibrary.DataSetHelper.CreateWorkbook("MyExcelFile.xls", dsTest);
    }
