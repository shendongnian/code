    protected void btnExportToExcel_Click(object sender, EventArgs e)
    {
        Response.Clear();
        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        Response.AddHeader("content-disposition", "attachment;  filename=ExcelDemo.xlsx");
        Response.BinaryWrite(ExcelHelper.GetByteArray(datatable));
        Response.End();
    }
