    try
    {
        response = (HttpWebResponse)request.GetResponse();
        code = response.StatusCode;
    }
    catch (WebException we)
    {
        code = ((HttpWebResponse)we.Response).StatusCode;
    }
