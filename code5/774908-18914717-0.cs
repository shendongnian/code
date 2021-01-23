    byte[] content = "Select Your Bytes From Database";
    HttpContext.Current.Response.Buffer = false;
    HttpContext.Current.Response.Clear();
    HttpContext.Current.Response.ClearContent();
    HttpContext.Current.Response.ClearHeaders();
    HttpContext.Current.Response.AppendHeader("content-disposition","attachment;filename=" + fileName);
    HttpContext.Current.Response.ContentType = "Application/pdf";
    //Write the file content directly to the HTTP content output stream.
    HttpContext.Current.Response.BinaryWrite(content);
    HttpContext.Current.Response.Flush();
    HttpContext.Current.Response.End();
