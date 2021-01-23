    var fileBytes=File.ReadAllBytes(filePath);
    Response.Clear();
    Response.ClearHeaders();
    Response.ContentType = "text/html; charset=UTF-8";
    Response.AddHeader("Content-Disposition", "attachment; filename=\"" + filePath + "\"");
    Response.AddHeader("Content-Length", fileBytes.Length);
    Response.OutputStream.Write(fileBytes, 0, fileBytes.Length);
    Response.Flush();
    Response.End();
