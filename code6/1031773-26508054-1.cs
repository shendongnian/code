    statusCode = HttpStatusCode.ServiceUnavailable; // set a default
    ...
    try
    {
        ...
    }
    catch (WebException we)
    {
        if (we.Response != null)
        {
            statusCode = ((HttpWebResponse)we.Response).StatusCode;
        }
    }
