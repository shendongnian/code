    [WebMethod]
    [SoapDocumentMethod(OneWay = true)]
    public void Silent()
    {
        var address = HttpContext.Current.Request.UserHostAddress;
    
        // Do something with address
        Trace.Write(address);
    }
