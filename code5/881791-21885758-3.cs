      public static List<RootObject> GetItems(string user, string key, Int32 tid, Int32 pid)
        {
            // Customize URL according to geo location parameters
            var url = string.Format(uniqueItemUrl, user, key, tid, pid);
    
            // Syncronious Consumption
            var syncClient = new WebClient();
    
            var content = syncClient.DownloadString(url);
    
            return JsonConvert.DeserializeObject<List<RootObject>>(content);
    
        }
