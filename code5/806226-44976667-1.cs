    /// <summary>
    /// Handler to assign the MD5 hash value if content is present
    /// </summary>
    public class RequestContentMd5Handler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (request.Content == null)
            {
                return await base.SendAsync(request, cancellationToken);
            }
            await request.Content.AssignMd5Hash();
            var response = await base.SendAsync(request, cancellationToken);
            return response;
        }
    }
