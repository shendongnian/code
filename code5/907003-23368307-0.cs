    ...
    byte[] docFile = null;
    ...
    Response.ClearHeaders();
    Response.AddHeader("Content-Disposition", "attachment; filename=\"Document.doc\"");
    Response.ContentType = "application/x-unknown";
    Response.BinaryWrite(docFile);
    Response.End();
