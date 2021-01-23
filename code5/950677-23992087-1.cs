       var operationContext = OperationContext.Current;
       var requestContext = operationContext .RequestContext;
       var headers = requestContext.RequestMessage.Headers;
       int headerIndex = headers.FindHeader("ClientIdentification", "");
       var clientHeaderString = headers.GetHeader<string>(headerIndex);
