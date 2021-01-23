    [WebMethod]
    public void Download(string FileName)
    {
        HttpContext.Current.Response.ContentType="image/png";
        HttpContext.Current.Response.BinaryWrite(imagebytes);
        HttpContext.Current.Response.End();
    }
