    public class HeaderProvider : IHeaderProvider
    {
        private readonly HttpContextBase _httpContextBase;
        public HeaderProvider(HttpContextBase httpContextBase)
        {
            _httpContextBase = httpContextBase;
        }
        public Guid GetOnBehalfOf()
        {
            var xOnBehalfOf = _httpContextBase.Request.Headers.Get("X-OnBehalfOfId");
            Guid userId;
            if (string.IsNullOrWhiteSpace(xOnBehalfOf))
                throw new Exception("Missing user ID");
            if (Guid.TryParse(xOnBehalfOf, out userId))
            {
                return userId;
            }
            throw new Exception("Invalid user ID");
        }
    }
