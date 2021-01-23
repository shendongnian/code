    try
    {
        HttpWebRequest q = (HttpWebRequest)WebRequest.Create(theUrl);
        HttpWebResponse r = (HttpWebResponse)q.GetResponse();
        if (r.StatusCode != HttpStatusCode.NotFound)
        {
            // page does not exist
        }
    }
    catch (WebException ex)
    {
        HttpWebResponse r = ex.Response as HttpWebResponse;
        if (r != null && r.StatusCode != HttpStatusCode.NotFound)
        {
            // page does not exist
        }
    }
