    string name = GetTitle(url);
    public string GetTitle(string url)
    {
        string id = GetArgs(url, "v", '?');
        WebClient client = new WebClient();
        return GetArgs(client.DownloadString("http://youtube.com/get_video_info?video_id=" + id), "title", '&');
    }
    private string GetArgs(string args, string key, char query)
    {
        int iqs = args.IndexOf(query);
        string querystring = null;
        if (iqs != -1)
        {
            querystring = (iqs < args.Length - 1) ? args.Substring(iqs + 1) : String.Empty;
            NameValueCollection nvcArgs = HttpUtility.ParseQueryString(querystring);
            return nvcArgs[key];
        }
        return String.Empty; // or throw an error
    }
