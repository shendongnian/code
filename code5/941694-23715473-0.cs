    void CompareVersions()
    {
        WebClient client = new WebClient();
        var serverVersion = client.DownloadString("http://yourwebsite.com/version.txt");
        using (StreamReader sr = new StreamReader("file.txt"))
        {
            if (Convert.ToInt32(serverVersion) > Convert.ToInt32(sr.ReadLine()))
            {
                // server version bigger
            }
            else
            {
                // up to date
            }
        }
    }
