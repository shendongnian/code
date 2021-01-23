    System.Web.HttpResponse response = System.Web.HttpContext.Current.Response;
    response.ClearContent();
    response.Clear();
    response.ContentType = "text/plain";     //alternatively change to the content-type of your file
    response.AddHeader("Content-Disposition", "attachment; filename=" + fileName + ";");
    response.TransmitFile("Path on server to downloadable file");
    response.Flush();    
    response.End();
