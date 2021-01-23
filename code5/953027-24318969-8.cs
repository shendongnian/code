    serverResponseEquals: 'OK',
----------------------
    [WebMethod]
    public void keepalive()
    {
    	HttpContext.Current.Response.Write("OK"); 
    	HttpContext.Current.Response.End();
    }
