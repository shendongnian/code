    static public Task<WebResponse> GetResponseTapAsync(this WebRequest request)
    {
        return Task.Factory.FromAsync(
             (asyncCallback, state) =>
                 request.BeginGetResponse(asyncCallback, state),
             (asyncResult) =>
                 request.EndGetResponse(asyncResult), null);
    }
