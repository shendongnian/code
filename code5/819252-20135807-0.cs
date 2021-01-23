    public static UserItem DownloadJSONString(string urlJson)
    {
        using (WebClient wc = new WebClient())
        {
            wc.Encoding = Encoding.UTF8;
            var json = wc.DownloadString(urlJson);
            UserItem userItems = JsonConvert.DeserializeObject<RootObject>(json);
    
            return userItems;
        }            
    }
