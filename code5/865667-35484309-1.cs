    public static class HttpExtentions
    {
        public static IHttpActionResult AddHeader(this IHttpActionResult result,
            string headerName, IEnumerable<string> headerValues)
        {
            return new HeaderActionResult(result, headerName, headerValues);
        }
        private class HeaderActionResult : IHttpActionResult
        {
            private readonly IHttpActionResult httpAction;
            private readonly Tuple<string, IEnumerable<string>> header;
            public HeaderActionResult(IHttpActionResult httpAction, string headerName,
                IEnumerable<string> headerValues)
            {
                this.httpAction = httpAction;
                header = Tuple.Create(headerName, headerValues);
            }
            public async Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
            {
                var response = await httpAction.ExecuteAsync(cancellationToken);
                response.Headers.Add(header.Item1, header.Item2);
                return response;
            }
        }
    }
