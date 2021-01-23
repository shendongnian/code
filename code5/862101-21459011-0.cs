    public override sealed void ExecuteResult(ControllerContext context)
    {
        IWorkbook workbook = XlsData.CreateTestWorkbook().Workbook;
    
        HttpResponseBase response = context.HttpContext.Response;
        response.Clear();
        response.ContentType = "application/vnd.ms-excel";
        response.Headers.Add("content-disposition", "attachment;  filename=Test.xls");
    
        using (var ms = new MemoryStream())
        {
            workbook.Write(ms);
            ms.WriteTo(response.OutputStream);
        }
        response.End();
    }
