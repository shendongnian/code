    Response.ContentType = "Application/pdf";
    Response.AppendHeader("Content-Disposition", "attachment; filename=Filename.pdf");
    Response.TransmitFile("C:\\Temp\\Filename.pdf");
    Response.Flush();
    Response.Close();
    Response.End();
