    [WebMethod]
    public void Download(string FileName)
    {
        Response.ContentType="image/png";
        Response.BinaryWrite(imagebytes);
        Response.End();
    }
