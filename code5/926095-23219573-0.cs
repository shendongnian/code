    try
    {
        Response.Clear();
        Response.ClearHeaders();
        Response.ClearContent();
        Response.AddHeader("content-disposition", "attachment; filename=" + _Filename);
        Response.AddHeader("Content-Type", "application/Word");
        Response.ContentType = "application/octet-stream";
        Response.AddHeader("Content-Length", _FileLength_in_bytes);
        Response.BinaryWrite(_Filedata_bytes);
        Response.End();
    }
    catch (ThreadAbortException)
    { }
    finally
    {
    }
