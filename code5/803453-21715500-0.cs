    public class CompressionFeature : IPlugin
    {
        public void Register(IAppHost appHost)
        {
            appHost.ResponseFilters.Add((request, response, dto) =>
            {
                if (dto == null || dto is AuthResponse || dto is CompressedResult || dto is Exception) return;
                using (var serializationContext = new HttpRequestContext(request, response, dto))
                {
                    if (!serializationContext.RequestAttributes.AcceptsDeflate && !serializationContext.RequestAttributes.AcceptsGzip) return;
                    var serializedDto = EndpointHost.ContentTypeFilter.SerializeToString(serializationContext, dto);
                    var callback = request.GetJsonpCallback();
                    var isJsonpRequest = EndpointHost.Config.AllowJsonpRequests && !string.IsNullOrEmpty(callback);
                    if (isJsonpRequest)
                    {
                        serializedDto = (callback + "(") + serializedDto + ")";
                        serializationContext.ResponseContentType = ContentType.JavaScript;
                    }
                    var compressedBytes = serializedDto.Compress(serializationContext.CompressionType);
                    var compressedResult = new CompressedResult(compressedBytes, serializationContext.CompressionType, serializationContext.ResponseContentType);
                    response.WriteToResponse(compressedResult, serializationContext.ResponseContentType);
                }
            });
        }
    }
