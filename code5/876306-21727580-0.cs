    var request = (HttpWebRequest)WebRequest.Create(serviceUrl);
    request.Timeout = 5000;
    try
    {
        var response = (HttpWebResponse)request.GetResponse();
        if (response.StatusCode == HttpStatusCode.OK)
        {
            //perform some operations.
        }
    }
    catch (WebException wex)
    {
        if (wex.Message == "The operation has timed out")
        {
            //   do stuff
        }
    }
