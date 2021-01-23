    Response.Clear();
    Response.ContentType = "application/pdf";
    Response.AppendHeader("Content-Disposition", "attachment; filename=FileName.pdf");
    Response.TransmitFile(filePath);
    Response.End(); 
