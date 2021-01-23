    try
    {
        // do your stuff
    }
    catch (WebException webEx)
    {
        var response = webEx.Response as HttpWebResponse;
        if (response != null)
        {
           Log.Add(LogTypes.Error, 100, "HTTP StatusCode = " + (int)response.StatusCode);
        }
    }
    catch (Exception ex)
    {
        Log.Add(LogTypes.Error, 100, ex.ToString());
    }
