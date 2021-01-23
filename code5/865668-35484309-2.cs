    public static class HttpExtentions
    {
        public static IHttpActionResult AddHeader(this IHttpActionResult action,
            string headerName, IEnumerable<string> headerValues)
        {
            return new HeaderActionResult(action, headerName, headerValues);
        }
        public static IHttpActionResult AddHeader(this IHttpActionResult action,
            string headerName, string header)
        {
            return AddHeader(action, headerName, new[] {header});
        }
        private class HeaderActionResult : IHttpActionResult
        {
            private readonly IHttpActionResult action;
            private readonly Tuple<string, IEnumerable<string>> header;
            public HeaderActionResult(IHttpActionResult action, string headerName,
                IEnumerable<string> headerValues)
            {
                this.action = action;
                header = Tuple.Create(headerName, headerValues);
            }
            public async Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
            {
                var response = await action.ExecuteAsync(cancellationToken);
                response.Headers.Add(header.Item1, header.Item2);
                return response;
            }
        }
    }
