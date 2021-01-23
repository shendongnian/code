    Response.Clear();
    Response.ContentType = "application/octet-stream";
    Response.AddHeader("Content-Disposition", String.Format("attachment;filename=\"{0}\"",    fileName));
    Response.AddHeader("Content-Length", eftTextFile.Length.ToString());
    Response.OutputStream.Write(eftTextFile, 0, eftTextFile.Length);
    Response.Flush();
    //now signal the httpapplication to stop processing the request.
    HttpContext.Current.ApplicationInstance.CompleteRequest();
