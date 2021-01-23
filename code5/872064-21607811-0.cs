    using (WebResponse webResponse = webRequest.GetResponse())
    {
        var httpResponse = (HttpWebResponse) webResponse;
        headers.Add("URL: " + url);
        headers.Add("Status Code: " + (int) httpResponse.StatusCode);
        headers.Add("Status Description: " + httpResponse.StatusDescription + "\n");
    }
