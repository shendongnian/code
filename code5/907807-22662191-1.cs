    private void AddCustomHeader(System.ServiceModel.OperationContextScope scope)
    {
     	dynamic reqProp = new System.ServiceModel.Channels.HttpRequestMessageProperty();
	    reqProp.Headers.Add("User-Agent", "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT; blah; blah; blah)");
    	System.ServiceModel.OperationContext.Current.OutgoingMessageProperties(System.ServiceModel.Channels.HttpRequestMessageProperty.Name) = reqProp;
    }
    
