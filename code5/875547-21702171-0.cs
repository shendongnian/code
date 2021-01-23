    try
    {
        // ...
    }
    catch ( WebException ex )
    {
        var response = (HttpWebResponse) ex.Response;
        var errorCode = response.StatusCode;
        Log.Add(LogTypes.Error, errorCode, ex.Message);
    }
