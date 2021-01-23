    public ActionResult DownloadFile(XXXModel model)
    {
        using (var workbook = new XLWorkbook(XLEventTracking.Disabled))
        {
            // create worksheets etc..
            // return 
            using (var stream = new MemoryStream())
            {
                workbook.SaveAs(stream);
                stream.Flush();
    
                return new FileContentResult(stream.ToArray(),
                       "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
                       {
                           FileDownloadName = "XXXName.xlsx"
                       };
            }
        }
     
