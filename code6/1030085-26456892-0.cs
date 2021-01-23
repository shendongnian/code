    public ActionResult PrintPO(string type)
    {
        LocalReport lr = new LocalReport();
        string path = Url.Content(Server.MapPath("~/Report/RepPurchaseOrder.rdlc"));
        if (System.IO.File.Exists(path))
        {
            lr.ReportPath = path;
        }
        else
        {
            return Content("Report File Not Found!");
        }
        ReportDataSource rd = new ReportDataSource("Data", list));
        lr.DataSources.Add(rd);
        string reportType = type;
        string mimeType;
        string encoding;
        string fileNameExtension;
        string id="Dynamic ID Will Be Here";
        string deviceInfo =
        "<DeviceInfo>" +
        "  <OutputFormat>" + id + "</OutputFormat>" +
        "  <PageWidth>10in</PageWidth>" +
        "  <PageHeight>10in</PageHeight>" +
        "  <MarginTop>0.5in</MarginTop>" +
        "  <MarginLeft>1in</MarginLeft>" +
        "  <MarginRight>1in</MarginRight>" +
        "  <MarginBottom>0.5in</MarginBottom>" +
        "</DeviceInfo>";
        Warning[] warnings;
        string[] streams;
        byte[] renderedBytes;
        renderedBytes = lr.Render(
            reportType,
            deviceInfo,
            out mimeType,
            out encoding,
            out fileNameExtension,
            out streams,
            out warnings);
        //Saving renderedBytes to File ~/Content/PDF/Result1.pdf
        var filesDir = Server.MapPath(@"~/Content/PDF");
        if (!Directory.Exists(filesDir)) {
            Directory.CreateDirectory(filesDir);
        }
        var filePath = Path.Combine(filesDir, "Result1.pdf");
        using (FileStream fileStream = System.IO.File.Create(filePath, renderedBytes.Length)) {
            fileStream.Write(renderedBytes, 0, renderedBytes.Length);
        }
        FileContentResult fileResult = File(renderedBytes, mimeType);
        return fileResult;
    }
