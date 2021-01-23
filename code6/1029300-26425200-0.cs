    try
    {
        request.GetResponse();
    }
    catch (WebException e)
    {
        if (e.Response != null)
            return getResponseBody(e.Response);
        else
            throw;
    }
