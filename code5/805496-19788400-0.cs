    public System.IO.Stream GetInfo()
    {
        OutgoingWebResponseContext context = WebOperationContext.Current.OutgoingResponse;
        context.ContentType = "text/plain";
        return new System.IO.MemoryStream(ASCIIEncoding.Default.GetBytes("{lhs:\"1 Euro\",rhs: \"1.3711 U.S. dollars\",error: \"\",icc: true}"));
    }
