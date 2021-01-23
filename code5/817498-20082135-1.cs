    [OperationContract, WebGet(ResponseFormat = WebMessageFormat.Json)]
    public Stream SomeMethod(......)
    {
	    //Call other WS  and get the Json response
   	    var data = new MemoryStream(Encoding.UTF8.GetBytes(json));
	    WebOperationContext.Current.OutgoingResponse.ContentType = "application/json; charset=utf-8";
	    WebOperationContext.Current.OutgoingResponse.ContentLength = data.Length;
		
 	    return data;
    }
