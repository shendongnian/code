    public static string ReadUrlToString(string url, string method, string postParams, string userName, string password, string domain)
    {
        var wc = new WebClient();
        // set the user agent to IE6
        wc.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; .NET CLR 1.0.3705;)");
        AssignCredentials(wc, userName, password, domain);
        try
        {
            if (Is.EqualString(method, "POST"))
            {
                // Eg "field1=value1&amp;field2=value2"
                var bret = wc.UploadData(url, "POST", Encoding.UTF8.GetBytes(postParams));
                return Encoding.UTF8.GetString(bret);
            }
            // actually execute the GET request
            return wc.DownloadString(url);
        }
        catch (WebException we)
        {
            // WebException.Status holds useful information
            //throw as needed
        }
        catch (Exception ex)
        {
            // other errors
            //throw as needed
        }
    }
