    try
    {
        string html;
        using (WebClient client = new WebClient())
        {
            client.Headers.Add("Accept-Language", " en-US");
            client.Headers.Add("Accept", " text/html, application/xhtml+xml, */*");
            client.Headers.Add("User-Agent", "Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 6.1; Trident/5.0)");
            html = client.DownloadString("http://www.coleparmer.co.uk/Product/Turb_Std_Hach_2100q_Kit/WZ-99900-47");
        }
    }
    catch (WebException ex)
    {
        if (ex.Status == WebExceptionStatus.ProtocolError && ex.Response != null)
        {
            var resp = (HttpWebResponse)ex.Response;
            if (resp.StatusCode == HttpStatusCode.NotFound) // HTTP 404
            {
                //Handle it
            }
        }
        //Handle it
    }
