    string result;
    using (var webClient = new System.Net.WebClient())
    {
        webClient.Proxy=null;
        String url = "http://bg2.cba.pl/realmIP.txt";
        result = webClient.DownloadString(url);
    }
