    var excelStream = GetExcelByteStream("MyExcelFilename");
    context.Response.Clear(); 
    context.Response.AddHeader("Content-Disposition",  "attachment;filename="+context.Request.Form["txtFileName"].ToString()); 
    context.Response.AddHeader("Content-Length", excelStream.Length.ToString()); 
    context.Response.ContentType = "application/octet-stream"; 
    context.Response.BinaryWrite(excelStream); 
