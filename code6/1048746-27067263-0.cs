    var response = connector.ConnectorRequestOp(Request);
    
    if(response != null && response.Item != null)
    {
    	if(response.Item Is MP0123_ConnectorRequest_001_ResultResult)
    	{
    		var responseResult = response.Item As MP0123_ConnectorRequest_001_ResultResult;
    		// ...
    	}
    	else
    	{
    		var otherResult = response.Item As fileResult
    		// ...
    	}
    }
