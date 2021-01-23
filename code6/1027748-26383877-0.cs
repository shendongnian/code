    HttpWebResponse response = null;
    try
    {
        response = webRequest.GetResponse() as HttpWebResponse;
        if (response.StatusCode == HttpStatusCode.OK)
        {
            //do something
        }
    }
    catch (WebException ex) { }
    finally
    {
        if (response != null) response.Dispose();
    }
