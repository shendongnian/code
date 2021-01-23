    public class ValidationDelegationHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, CancellationToken cancellationToken)
        {
            try
            {
                return await base.SendAsync(request, cancellationToken);
            }
            catch (ValidationException ex)
            {
                return WebApiValidationHelper.ToResponseCode(ex);
            }
        }
    }
