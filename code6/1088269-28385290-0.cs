    private Tuple<string, string> _cookie;
    .
    .
    .
    private bool InitExport(string url)
            {
                webClient.Headers[HttpRequestHeader.Cookie] = String.Concat(_cookie.Item1, "=", _cookie.Item2);
    .
