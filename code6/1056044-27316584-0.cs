    Response.Clear();
    Response.ContentType = mimeType;
    Response.AddHeader("content-disposition", "attachment; filename=" + sFilename + "." + fileNameExtension);
    Response.BinaryWrite(renderedBytes);
    Response.End();
