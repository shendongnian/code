    /// <summary>
    /// Defines the expected members of a PostAuthenticateRequestProvider
    /// </summary>
    internal interface IPostAuthenticateRequestProvider
    {
        /// <summary>
        /// Applies a correctly setup principle to the Http request
        /// </summary>
        /// <param name="httpContext"></param>
        void ApplyPrincipleToHttpRequest(HttpContext httpContext);
    }
