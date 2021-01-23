    var response = await base.SendAsync(request, cancellationToken);
    if (response.StatusCode == HttpStatusCode.Unauthorized
        && !response.Headers.Contains(BasicAuthResponseHeader))
    {
      response.Headers.Add(
          BasicAuthResponseHeader, 
          BasicAuthResponseHeaderValue);
    }
    WasHttpExceptionThrown(response.Content);
