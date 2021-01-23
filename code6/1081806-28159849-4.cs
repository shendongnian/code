    class AppHost : AppHostBase
    {
        public virtual object OnPreExecuteServiceFilter(IService service,
            object request, IRequest httpReq, IResponse httpRes)
        {
            if (httpReq.Headers[HttpHeaders.ContentEncoding]
                .EqualsIgnoreCase(CompressionTypes.GZip))
            {
                //...
                return customRequest;
            }
            return request;
        }
    }
