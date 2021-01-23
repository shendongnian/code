        pdfFilePath = pdfFilePath + "/DownloadPastPapers.pdf";
        Response.Clear();
        Response.ContentType = "application/pdf";
        Response.AppendHeader("Content-Disposition", "attachment; filename=foo.pdf");
        Response.TransmitFile(pdfFilePath);
        Response.End(); 
