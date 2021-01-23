    try
    {
        HttpWebRequest requestChangelog = (HttpWebRequest)HttpWebRequest.Create(url);
        requestChangelog.Method = "GET";
        HttpWebResponse changelogResponse = (HttpWebResponse)requestChangelog.GetResponse();
    }
    catch (WebException we)
    {
        //handle the error
    }
    AskStatusCode((int)changelogResponse.StatusCode);
