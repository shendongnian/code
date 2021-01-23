    try
    {
        WebResponse response = request.GetResponse();
        if (response.StatusCode != System.Net.HttpStatusCode.OK) return null;
        //Continue by getting and parsing the response stream
