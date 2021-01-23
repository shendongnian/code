    // Create the cancelation token, when we don't get any feedback from server within 20 seconds
    var cancelHeadersToken = new CancellationTokenSource();
    cancelHeadersToken.CancelAfter(TimeSpan.FromSeconds(20)); // if we don't receive server headers after 20 seconds then something went wrong
    // We have another cancelation token, that allows the user to cancel the request, so here we create a linked token source which uses both tokens
    var linkedToken = CancellationTokenSource.CreateLinkedTokenSource(userCancelToken, cancelHeadersToken.Token);
    // The linked token is then used in GetAsync and we use the overload which allows to specify the HttpCompletionOption
    // We only want to receive headers and not all content
    var httpMessage = await customClient.CustomizedHttpClient.GetAsync(address, HttpCompletionOption.ResponseHeadersRead, linkedToken.Token).ConfigureAwait(false);
    
    // We can then download the content, and we still allow to cancel anything by the user
    using (var memoryStream = new MemoryStream(100000)) { // 100ko by default
        using (var stream = await httpMessage.Content.ReadAsStreamAsync().ConfigureAwait(false)) {
            await stream.CopyToAsync(memoryStream, 10000, userCancelToken).ConfigureAwait(false); // copy to memory stream 10ko per 10ko
        }
    
        string data = "";
        if (memoryStream.Length > 0) {
            var headers = httpMessage.Content.Headers;
            Encoding encoding;
            if (headers != null && headers.ContentType != null && headers.ContentType.CharSet != null) {
                encoding = Encoding.GetEncoding(headers.ContentType.CharSet);
            } else {
                encoding = Encoding.UTF8;
            }
            data = encoding.GetString(memoryStream.GetBuffer(), 0, (int)memoryStream.Length);
        }
        // Then you do whatever you want with data
    }				
