    public void ProcessRequest
    {
        Response.AddHeader("Content-Type", "text/plain");
        Response.Write(Request.Url.Query);
    }
