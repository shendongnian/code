    HttpWebRequest requestChangelog = new HttpWebRequest();
    HttpWebResponse changelogResponse = new HttpWebResponse();
    try
    {
        requestChangelog = (HttpWebRequest)HttpWebRequest.Create(url);
        requestChangelog.Method = "GET";
        changelogResponse = (HttpWebResponse)requestChangelog.GetResponse();
    }
    catch (WebException we)
    {
        //handle the error
    }
    AskStatusCode((int)changelogResponse.StatusCode);
