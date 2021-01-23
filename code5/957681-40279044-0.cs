     public class ApiGatewayHandler : DelegatingHandler
    {
        protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            try
            {
                var response = await base.SendAsync(request, cancellationToken);
                if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    var objectContent = response.Content as ObjectContent;
                    return await Task.FromResult(new ApiResult(HttpStatusCode.NotFound, VmsStatusCodes.RouteNotFound, "", objectContent == null ? null : objectContent.Value).Response());
                }
                return response;
            }
            catch (System.Exception ex)
            {
                return await Task.FromResult(new ApiResult(HttpStatusCode.BadRequest, VmsStatusCodes.UnHandledError, ex.Message, "").Response());
            }
        }
    }
