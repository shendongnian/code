    bool protocolError = false;
    try
    {
        webResponse = (HttpWebResponse)hwr.EndGetResponse(arGetResponse);
    }
    catch (WebException e)
    {
        if (e.Status == WebExceptionStatus.ProtocolError)
        {
            webResponse = (HttpWebResponse)e.Response;
            // 304s throw an exception... ridiculous!
            if (webResponse.StatusCode != HttpStatusCode.NotModified)
            {
                // This indicates that the response is valid but has a protocol-level error like 404
                protocolError = true;
            }
        }
        else
        {
            throw;
        }
    }
