    class WebHttpBehavior2Ex : WebHttpBehavior
    {
        protected override IDispatchMessageFormatter GetReplyDispatchFormatter(OperationDescription operationDescription, 
                                                                               ServiceEndpoint endpoint)
        {
            WebGetAttribute webGetAttribute = operationDescription.Behaviors.Find<WebGetAttribute>();
            DynamicResponseTypeAttribute mapAcceptedContentTypeToResponseEncodingAttribute = 
                operationDescription.Behaviors.Find<DynamicResponseTypeAttribute>();
            if (webGetAttribute != null && mapAcceptedContentTypeToResponseEncodingAttribute != null) {
                // We need two formatters, since we don't know what type we will need until runtime
                webGetAttribute.ResponseFormat = WebMessageFormat.Json;
                IDispatchMessageFormatter jsonDispatchMessageFormatter = 
                    base.GetReplyDispatchFormatter(operationDescription, endpoint);
                webGetAttribute.ResponseFormat = WebMessageFormat.Xml;
                IDispatchMessageFormatter xmlDispatchMessageFormatter = 
                    base.GetReplyDispatchFormatter(operationDescription, endpoint);
                return new DynamicFormatter() { 
                    jsonDispatchMessageFormatter = jsonDispatchMessageFormatter, 
                    xmlDispatchMessageFormatter = xmlDispatchMessageFormatter };
            }
            return base.GetReplyDispatchFormatter(operationDescription, endpoint);
        }
    }
