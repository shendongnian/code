      Sub ProcessRequest(ByVal context As HttpContext) _
        Implements IHttpHandler.ProcessRequest
        If context.Response.IsClientConnected Then
    	  If context.Request.UrlReferrer IsNot Nothing Then
    	    If context.Session("case_document_key") IsNot Nothing Then
    	    
