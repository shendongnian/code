var newRequest = CopyRequest(response);
base.SendAsync(newRequest, cancellationToken)
    .ContinueWith(t2 => tcs.SetResult(t2.Result));
This is the CopyRequest method with my improvements
* Instead of creating a new `StreamContent` and set it to null for `Redirect / Found / SeeOther` the content is only set if necesarry.
* RequestUri is only set if Location is set and takes into account that it may not be a relative uri.
* Most important: I check for the new Uri and if the host does not match I do not copy the autorization header, to prevent leaking your credentials to an external host.
private static HttpRequestMessage CopyRequest(HttpResponseMessage response)
{
    var oldRequest = response.RequestMessage;
    var newRequest = new HttpRequestMessage(oldRequest.Method, oldRequest.RequestUri);
    if (response.Headers.Location != null)
    {
        if (response.Headers.Location.IsAbsoluteUri)
        {
            newRequest.RequestUri = response.Headers.Location;
        }
        else
        {
            newRequest.RequestUri = new Uri(newRequest.RequestUri, response.Headers.Location);
        }
    }
    foreach (var header in oldRequest.Headers)
    {
        if (header.Key.Equals("Authorization", StringComparison.OrdinalIgnoreCase) && !(oldRequest.RequestUri.Host.Equals(newRequest.RequestUri.Host)))
        {
            //do not leak Authorization Header to other hosts
            continue;
        }
        newRequest.Headers.TryAddWithoutValidation(header.Key, header.Value);
    }
    foreach (var property in oldRequest.Properties)
    {
        newRequest.Properties.Add(property);
    }
    if (response.StatusCode == HttpStatusCode.Redirect
        || response.StatusCode == HttpStatusCode.Found
        || response.StatusCode == HttpStatusCode.SeeOther)
    {
        newRequest.Content = null;
        newRequest.Method = HttpMethod.Get;
    }
    else if (oldRequest.Content != null)
    {
        newRequest.Content = new StreamContent(oldRequest.Content.ReadAsStreamAsync().Result);
    }
    return newRequest;
}
